namespace UnifiedUI.GUI.ModButtons {
    public class NetworkDetectiveButton : GenericModButton {
        public static NetworkDetectiveButton Instance;
        public NetworkDetectiveButton() : base() => Instance = this;
        public override string SpritesFileName => "uui_network_detective.png";
        public override string Tooltip => "Network Detective";
        public override ToolBase Tool => GetTool("NetworkDetectiveTool");

        public override void Awake() {
            base.Awake();
            //ActivationKey = GetInputKey("NetworkDetective.Tool.NetworkDetectiveTool, NetworkDetective", "ActivationShortcut");
        }
    }
}
