using SCRP.BLL;
using SCRP.DAL.EF;
using SCRP.Web.Models.Home;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;

namespace SCRP.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IMemberBLL _memberBLL;
        //private readonly IPostBLL _postBLL;
        //private readonly IPetBLL _petBLL;
        //private readonly IImageBLL _imageBLL;
        //private readonly IImagePostMappingBLL _imagePostMappingBLL;
        //private readonly IHelpCampaignDetailBLL _helpCampaignDetailBLL;

        //public HomeController(IMemberBLL memberBLL, IPostBLL postBLL, IPetBLL petBLL, IImageBLL imageBLL, IImagePostMappingBLL imagePostMappingBLL,IHelpCampaignDetailBLL helpCampaignDetailBLL)
        //{
        //    _memberBLL = memberBLL;
        //    _postBLL = postBLL;
        //    _petBLL = petBLL;
        //    _imageBLL = imageBLL;
        //    _imagePostMappingBLL = imagePostMappingBLL;
        //    _helpCampaignDetailBLL = helpCampaignDetailBLL;
        //}
        // GET: Home

        public DatabaseContext GetDatabaseContext()
        {
            DatabaseContext context = new DatabaseContext();
            context.Configuration.LazyLoadingEnabled = false;
            return context;
        }

        public ActionResult Index()
        {

            //ContextInit.InitializeDB();
            DatabaseContext context = GetDatabaseContext();
            var purePostList = context.Posts.Include("Member").
                Include("HelpCampaignDetail").Include("Pet").Include("Pet.PetType").Include("ImagePostMappings").Where(x=> !x.IsDeleted).OrderByDescending(x => x.Id).ToList();

            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.LastPosts = purePostList;
            //var foundedPostCount = purePostList.Where(x => x.IsFounded && x.PostTypeId == Foundation.Enums.PostTypes.Missing).Count();
            //var totalRegisteredCount = purePostList.Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Missing).Count();
            //var campaignPosts = purePostList.Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Campaign && !x.IsDeleted);
            return View(homeViewModel);
            //var purePostList = _postBLL.GetList().ToList();
            //var lastPosts = purePostList.Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Missing && !x.IsDeleted).OrderByDescending(x => x.Id).Take(10).ToList();
            //var foundedPostCount = purePostList.Where(x => x.IsFounded && x.PostTypeId == Foundation.Enums.PostTypes.Missing).Count();
            //    var totalRegisteredCount = purePostList.Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Missing).Count();
            //var campaignPosts = purePostList.Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Campaign && !x.IsDeleted);

            //foreach (var item in campaignPosts)
            //{
            //    var helpCampaignDetailId = item.HelpCampaignDetailId;
            //    if (helpCampaignDetailId.HasValue && helpCampaignDetailId.Value != default)
            //    {
            //        var helpCampaignDetail = _helpCampaignDetailBLL.GetById(helpCampaignDetailId.Value);

            //        item.HelpCampaignDetail = helpCampaignDetail;
            //    }
            //}

            //foreach (var item in lastPosts)
            //{
            //    var petId = item.PetId;
            //    if (petId != default)
            //    {
            //        var pet = _petBLL.GetById(petId);

            //        item.Pet = pet;
            //    }
            //}

            //HomeViewModel homeViewModel = new HomeViewModel();
            //homeViewModel.LastPosts = lastPosts;
            //homeViewModel.TotalCampaingValue = campaignPosts.Sum(x => x.HelpCampaignDetail.CollectedAmount);
            //homeViewModel.TotalFoundedPets = foundedPostCount;
            //homeViewModel.TotalRegisteredPets = totalRegisteredCount;

            //return View(homeViewModel);
        }

        public ActionResult Contact() //iletişim
        {
            return View();
        }

        public ActionResult Donation()
        {
            //Donation sayfası
            return View();
        }

        public ActionResult RegisterPetInfo()
        {
            //Register Info page
            return View();
        }
    }
}