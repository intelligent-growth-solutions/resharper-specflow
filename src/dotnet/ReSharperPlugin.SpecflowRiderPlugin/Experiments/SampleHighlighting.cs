

using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using ReSharperPlugin.SpecflowRiderPlugin.Experiments;

namespace ReSharperPlugin.SpecflowRiderPlugin.Experiments
{
    // [RegisterConfigurableSeverity(
    //     SeverityId,
    //     null,
    //     HighlightingGroupIds.CodeSmell,
    //     Message,
    //     Description,
    //     Severity.WARNING)]
    // [ConfigurableSeverityHighlighting(
    //     SeverityId,
    //     CSharpLanguage.Name,
    //     OverlapResolve = OverlapResolveKind.ERROR,
    //     OverloadResolvePriority = 0,
    //     ToolTipFormatString = Message)]
    public class SampleHighlighting : IHighlighting
    {
        public const string SeverityId = nameof(SampleHighlighting);
        public const string Message = "Sample highlighting message";
        public const string Description = "Sample highlighting description";
        
        public SampleHighlighting(ICSharpDeclaration declaration)
        {
            Declaration = declaration;
        }

        public ICSharpDeclaration Declaration { get; }

        public bool IsValid()
        {
            return Declaration.IsValid();
        }

        public DocumentRange CalculateRange()
        {
            return Declaration.NameIdentifier?.GetHighlightingRange() ?? DocumentRange.InvalidRange;
        }

        public string ToolTip => Message;
        
        public string ErrorStripeToolTip
            => $"Sample highlighting error tooltip for '{Declaration.DeclaredName}'";
    }
}