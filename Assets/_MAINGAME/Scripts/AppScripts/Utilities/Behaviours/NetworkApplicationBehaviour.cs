using _MAINGAME.Scripts.AppScripts.Utilities.Behaviours;
using Fusion;

namespace _MAINGAME.Scripts.AppScripts.Utilities.Repository
{
    public class NetworkApplicationBehaviour : NetworkBehaviour
    {
        public void SetupSingleton()
        {
            ApplicationBehaviourUtils.SetupSingleton(this);
        }

        public void InjectComponent()
        {
            ApplicationBehaviourUtils.InjectComponents(this);
        }

        public override void Spawned()
        {
            SetupSingleton();
            InjectComponent();
        }
    }
}