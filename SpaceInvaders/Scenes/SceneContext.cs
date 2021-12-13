using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Scenes
{
    class SceneContext
    {
        SceneState pSceneState;
        SceneSelect poSceneSelect;
        ScenePlay poScenePlay;
        SceneDeath poSceneDeath;
        SceneOver poSceneOver;
        SceneLevelReset poSceneLevelReset;
        SceneOverReset poSceneOverReset;

        public enum Scene
        {
            Select,
            Play,
            Over,
            Death,
            LevelReset,
            OverReset
        }

        public SceneContext()
        {
            // reserve the states
            this.poSceneSelect = new SceneSelect();
            this.poScenePlay = new ScenePlay();
            this.poSceneDeath = new SceneDeath();
            this.poSceneOver = new SceneOver();
            this.poSceneLevelReset = new SceneLevelReset();
            this.poSceneOverReset = new SceneOverReset();

            // initialize to the select state
            this.pSceneState = this.poSceneSelect;
            this.pSceneState.TransitionTo();
        }

        public SceneState GetState()
        {
            return this.pSceneState;
        }
        public void SetState(Scene eScene)
        {
            switch (eScene)
            {
                case Scene.Select:
                    this.Transition(this.poSceneSelect);
                    break;
                case Scene.Play:
                    this.Transition(this.poScenePlay);
                    break;
                case Scene.Death:
                    this.Transition(this.poSceneDeath);
                    break;
                case Scene.Over:
                    this.Transition(this.poSceneOver);
                    break;
                case Scene.LevelReset:
                    this.Transition(this.poSceneLevelReset);
                    break;
                case Scene.OverReset:
                    this.Transition(this.poSceneOverReset);
                    break;

            }
        }

        private void Transition(SceneState pSceneState)
        {
            //Transition out of the current state
            this.pSceneState.TransitionFrom();

            //Make the give state the context state
            this.pSceneState = pSceneState;

            //Transition to the new state
            this.pSceneState.TransitionTo();
        }

    }
}
