namespace FluentHtmlExample.Core.FluentHtml
{
    public interface IWantBehaviours<TModel> : IWantBehaviours where TModel : class
    {
        void SetBehavioursContainer(BehaviorsContainer<TModel> behaviorsContainer);
    }
}