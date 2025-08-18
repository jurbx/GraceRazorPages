using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.Shared
{
    public class DeleteFileModel : PageModel
    {
        private readonly IS3BucketService s3BucketService;
        private readonly IImageService imageService;

        public DeleteFileModel(IS3BucketService s3BucketService, IImageService imageService) 
        {
            this.s3BucketService = s3BucketService;
            this.imageService = imageService;
        }

        public async Task<IActionResult> OnGetAsync(string filepath, string returnUrl)
        {
            await s3BucketService.DeleteFileAsync(filepath);
            await imageService.DeleteByFilepathAsync(filepath);
            return Redirect(returnUrl);
        }
    }
}
