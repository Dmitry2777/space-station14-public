using SS14.Client.Graphics;
using SS14.Client.Graphics.Drawing;
using SS14.Client.Interfaces.ResourceManagement;
using SS14.Client.ResourceManagement;
using SS14.Client.UserInterface;
using SS14.Client.UserInterface.Controls;
using SS14.Client.UserInterface.CustomControls;
using SS14.Shared.IoC;
using SS14.Shared.Maths;

namespace Content.Client.UserInterface
{
    public sealed class NanoStyle
    {
        private static readonly Color NanoGold = Color.FromHex("#A88B5E");

        private static readonly StyleBox WindowBackground = new StyleBoxFlat
            {BackgroundColor = Color.FromHex("#25252A")};

        public Stylesheet Stylesheet { get; }

        public NanoStyle()
        {
            var resCache = IoCManager.Resolve<IResourceCache>();
            var notoSans14 = new VectorFont(resCache.GetResource<FontResource>("/Nano/NotoSans/NotoSans-Regular.ttf"),
                14);
            var notoSans28 = new VectorFont(resCache.GetResource<FontResource>("/Nano/NotoSans/NotoSans-Regular.ttf"),
                28);
            var notoSansBold16 =
                new VectorFont(resCache.GetResource<FontResource>("/Nano/NotoSans/NotoSans-Bold.ttf"), 16);
            var textureCloseButton = resCache.GetResource<TextureResource>("/Nano/cross.svg.png").Texture;
            var windowHeaderTex = resCache.GetResource<TextureResource>("/Nano/window_header.png").Texture;
            var windowHeader = new StyleBoxTexture
            {
                Texture = windowHeaderTex,
                PatchMarginBottom = 3,
                ExpandMarginBottom = 3,
            };
            var buttonNormalTex = resCache.GetResource<TextureResource>("/Nano/button_normal.png").Texture;
            var buttonNormal = new StyleBoxTexture
            {
                Texture = buttonNormalTex,
            };
            buttonNormal.SetMargin(StyleBox.Margin.All, 2);
            buttonNormal.SetContentMarginOverride(StyleBox.Margin.Left | StyleBox.Margin.Right, 4);

            var buttonHoverTex = resCache.GetResource<TextureResource>("/Nano/button_hover.png").Texture;
            var buttonHover = new StyleBoxTexture
            {
                Texture = buttonHoverTex,
            };
            buttonHover.SetMargin(StyleBox.Margin.All, 2);
            buttonHover.SetContentMarginOverride(StyleBox.Margin.Left | StyleBox.Margin.Right, 4);

            var buttonPressedTex = resCache.GetResource<TextureResource>("/Nano/button_pressed.png").Texture;
            var buttonPressed = new StyleBoxTexture
            {
                Texture = buttonPressedTex,
            };
            buttonPressed.SetMargin(StyleBox.Margin.All, 2);
            buttonPressed.SetContentMarginOverride(StyleBox.Margin.Left | StyleBox.Margin.Right, 4);

            var buttonDisabledTex = resCache.GetResource<TextureResource>("/Nano/button_disabled.png").Texture;
            var buttonDisabled = new StyleBoxTexture
            {
                Texture = buttonDisabledTex,
            };
            buttonDisabled.SetMargin(StyleBox.Margin.All, 2);
            buttonDisabled.SetContentMarginOverride(StyleBox.Margin.Left | StyleBox.Margin.Right, 4);


            Stylesheet = new Stylesheet(new[]
            {
                // Default font.
                new StyleRule(
                    new SelectorElement(null, null, null, null),
                    new[]
                    {
                        new StyleProperty("font", notoSans14),
                    }),

                // Window title.
                new StyleRule(
                    new SelectorElement(typeof(Label), new[] {SS14Window.StyleClassWindowTitle}, null, null),
                    new[]
                    {
                        new StyleProperty(Label.StylePropertyFontColor, NanoGold),
                        new StyleProperty(Label.StylePropertyFont, notoSansBold16),
                    }),
                // Window background.
                new StyleRule(
                    new SelectorElement(null, new[] {SS14Window.StyleClassWindowPanel}, null, null),
                    new[]
                    {
                        new StyleProperty(Panel.StylePropertyPanel, WindowBackground),
                    }),
                // Window header.
                new StyleRule(
                    new SelectorElement(typeof(Panel), new[] {SS14Window.StyleClassWindowHeader}, null, null),
                    new[]
                    {
                        new StyleProperty(Panel.StylePropertyPanel, windowHeader),
                    }),
                // Window close button base texture.
                new StyleRule(
                    new SelectorElement(typeof(TextureButton), new[] {SS14Window.StyleClassWindowCloseButton}, null,
                        null),
                    new[]
                    {
                        new StyleProperty(TextureButton.StylePropertyTexture, textureCloseButton),
                        new StyleProperty(Control.StylePropertyModulateSelf, Color.FromHex("#4B596A")),
                    }),
                // Window close button hover.
                new StyleRule(
                    new SelectorElement(typeof(TextureButton), new[] {SS14Window.StyleClassWindowCloseButton}, null,
                        TextureButton.StylePseudoClassHover),
                    new[]
                    {
                        new StyleProperty(Control.StylePropertyModulateSelf, Color.FromHex("#7F3636")),
                    }),
                // Window close button pressed.
                new StyleRule(
                    new SelectorElement(typeof(TextureButton), new[] {SS14Window.StyleClassWindowCloseButton}, null,
                        TextureButton.StylePseudoClassPressed),
                    new[]
                    {
                        new StyleProperty(Control.StylePropertyModulateSelf, Color.FromHex("#753131")),
                    }),

                // Regular buttons!
                new StyleRule(
                    new SelectorElement(typeof(Button), null, null, Button.StylePseudoClassNormal),
                    new[]
                    {
                        new StyleProperty(Button.StylePropertyStyleBox, buttonNormal),
                    }),
                new StyleRule(
                    new SelectorElement(typeof(Button), null, null, Button.StylePseudoClassHover),
                    new[]
                    {
                        new StyleProperty(Button.StylePropertyStyleBox, buttonHover),
                    }),
                new StyleRule(
                    new SelectorElement(typeof(Button), null, null, Button.StylePseudoClassPressed),
                    new[]
                    {
                        new StyleProperty(Button.StylePropertyStyleBox, buttonPressed),
                    }),
                new StyleRule(
                    new SelectorElement(typeof(Button), null, null, Button.StylePseudoClassDisabled),
                    new[]
                    {
                        new StyleProperty(Button.StylePropertyStyleBox, buttonDisabled),
                        new StyleProperty("font-color", Color.FromHex("#E5E5E581")),
                    }),

                // Main menu: Make those buttons bigger.
                new StyleRule(
                    new SelectorChild(
                        new SelectorElement(null, null, "mainMenuVBox", null),
                        new SelectorElement(typeof(Button), null, null, null)),
                    new[]
                    {
                        new StyleProperty("font", notoSans28),
                    }),

                // Main menu: also make those buttons slightly more separated.
                new StyleRule(new SelectorElement(typeof(BoxContainer), null, "mainMenuVBox", null),
                    new[]
                    {
                        new StyleProperty(BoxContainer.StylePropertySeparation, 2),
                    }),
            });
        }
    }
}
