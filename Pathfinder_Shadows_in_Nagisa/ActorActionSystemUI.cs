using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.UI;
using Stride.UI.Controls;

namespace PathfinderShadowsInNagisa
{
    public class ActorActionSystemUI : SyncScript
    {
        public Entity ActionUI;
        private List<Button> actionButtons;

        public override void Start()
        {
            CreateActorActionButtons();
            actionButtons = ActionUI.Get<UIComponent>().Page.RootElement
                .FindVisualChildrenOfType<Button>().ToList();
        }

        public override void Update()
        {
        }

        private void CreateActorActionButtons()
        {
            Entity actor = ActorActionSystem.Instance.selectedActor;

            List<BaseAction> actions = actor.GetAll<BaseAction>().ToList();
        }
    }
}
