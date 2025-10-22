using System.Collections.Generic;
using Platformer.Gameplay;
using TMPro;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class animates all token instances in a scene.
    /// This allows a single update call to animate hundreds of sprite 
    /// animations.
    /// If the tokens property is empty, it will automatically find and load 
    /// all token instances in the scene at runtime.
    /// </summary>
    public class TokenController : MonoBehaviour
    {
        [Tooltip("Frames per second at which tokens are animated.")]
        public float frameRate = 12;
        [Tooltip("Instances of tokens which are animated. If empty, token instances are found and loaded at runtime.")]
        public TokenInstance[] tokens;
        [Tooltip("UI text element used to display the collected haiku.")]
        public TextMeshProUGUI haikuText;

        readonly HashSet<int> collectedTokenIndices = new HashSet<int>();
        readonly List<int> collectedTokenOrder = new List<int>();
        string[] haikuVerses = System.Array.Empty<string>();
        int versesRequired;
        bool haikuCompleted;

        public IReadOnlyList<string> CollectedHaikuVerses => haikuVerses;
        public bool HaikuCompleted => haikuCompleted;

        float nextFrameTime = 0;

        [ContextMenu("Find All Tokens")]
        void FindAllTokensInScene()
        {
            tokens = UnityEngine.Object.FindObjectsByType<TokenInstance>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        }

        void Awake()
        {
            //if tokens are empty, find all instances.
            //if tokens are not empty, they've been added at editor time.
            if (tokens.Length == 0)
                FindAllTokensInScene();
            collectedTokenIndices.Clear();
            collectedTokenOrder.Clear();
            haikuCompleted = false;
            haikuVerses = new string[tokens.Length];
            versesRequired = 0;
            //Register all tokens so they can work with this controller.
            for (var i = 0; i < tokens.Length; i++)
            {
                tokens[i].tokenIndex = i;
                tokens[i].controller = this;
                if (!string.IsNullOrEmpty(tokens[i].haikuVerse))
                    versesRequired++;
            }
            UpdateHaikuDisplay();
        }

        void Update()
        {
            //if it's time for the next frame...
            if (Time.time - nextFrameTime > (1f / frameRate))
            {
                //update all tokens with the next animation frame.
                for (var i = 0; i < tokens.Length; i++)
                {
                    var token = tokens[i];
                    //if token is null, it has been disabled and is no longer animated.
                    if (token != null)
                    {
                        token._renderer.sprite = token.sprites[token.frame];
                        if (token.collected && token.frame == token.sprites.Length - 1)
                        {
                            token.gameObject.SetActive(false);
                            tokens[i] = null;
                        }
                        else
                        {
                            token.frame = (token.frame + 1) % token.sprites.Length;
                        }
                    }
                }
                //calculate the time of the next frame.
                nextFrameTime += 1f / frameRate;
            }
        }

        public void RegisterHaikuVerse(TokenInstance token)
        {
            if (haikuCompleted)
                return;
            if (token.tokenIndex < 0)
                return;
            if (string.IsNullOrEmpty(token.haikuVerse))
                return;
            if (!collectedTokenIndices.Add(token.tokenIndex))
                return;
            collectedTokenOrder.Add(token.tokenIndex);
            if (haikuVerses.Length <= token.tokenIndex)
                System.Array.Resize(ref haikuVerses, token.tokenIndex + 1);
            haikuVerses[token.tokenIndex] = token.haikuVerse;
            var collectedVerses = GetCollectedVerses();
            Debug.Log($"Haiku progress: {string.Join(" | ", collectedVerses)}");
            UpdateHaikuDisplay();
            if (versesRequired > 0 && collectedTokenIndices.Count >= versesRequired)
            {
                haikuCompleted = true;
                var ev = Schedule<PlayerHaikuCompleted>();
                ev.verses = collectedVerses;
            }
        }

        void UpdateHaikuDisplay()
        {
            if (haikuText == null)
                return;
            var verses = GetCollectedVerses();
            haikuText.text = verses.Length == 0 ? string.Empty : string.Join("\n", verses);
        }

        string[] GetCollectedVerses()
        {
            if (haikuVerses.Length == 0 || collectedTokenOrder.Count == 0)
                return System.Array.Empty<string>();
            var verses = new List<string>(collectedTokenOrder.Count);
            for (var i = 0; i < collectedTokenOrder.Count; i++)
            {
                var index = collectedTokenOrder[i];
                if (index < 0 || index >= haikuVerses.Length)
                    continue;
                var verse = haikuVerses[index];
                if (!string.IsNullOrWhiteSpace(verse))
                    verses.Add(verse.Trim());
            }
            return verses.ToArray();
        }

    }
}