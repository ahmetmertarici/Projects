using Blog.Data.Abstract;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Jobs
{
    public class ArticlePublishJob : IJob
    {
        private IArticleRepository _articleRepository;

        public ArticlePublishJob(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            // Örneğin, bekleyen ve yayınlanacak makaleleri alın.
            var articlesToPublish = await _articleRepository.GetArticlesToPublishAsync
                ();

            foreach (var article in articlesToPublish)
            {
                // Yayınlanma zamanı kontrol ediliyor.
                if (article.PublishDate.HasValue && article.PublishDate.Value <= DateTime.Now && !article.IsApproved)
                {
                    // Makalenin onay durumunu güncelleyin ve değişikliği kaydedin.
                    _articleRepository.UpdateIsApproved(article);
                }
            }

        }
    }
}
