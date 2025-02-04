using System.Threading.Tasks;
using AtlasEngine;
using AtlasEngine.ExternalTasks;
using warehouse.picking.api.Domain;
using Warehouse.Picking.Api.Processes.ExternalTasks.Intake.Payloads;
using Warehouse.Picking.Api.Services;

namespace Warehouse.Picking.Api.Processes.ExternalTasks.Intake
{
    [ExternalTaskHandler(topic: "Intake.Article.Match")]
    public class MatchArticleByGtinAndBundleHandler : IExternalTaskHandler<MatchArticlePayload, Article>
    {
        private readonly IntakeService _service;

        public MatchArticleByGtinAndBundleHandler(IntakeService service)
        {
            _service = service;
        }

        public Task<Article> HandleAsync(MatchArticlePayload input, ExternalTask task)
        {
            var article = _service.MatchUnfinishedArticleByGtinAndBundle(input.NoteId, input.Gtin, int.Parse(input.BundleId));
            return Task.FromResult(article);
        }
    }

}