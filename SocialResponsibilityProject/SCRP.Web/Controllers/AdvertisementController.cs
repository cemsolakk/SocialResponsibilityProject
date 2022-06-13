
using SCRP.DAL.EF;
using SCRP.Foundation.Entities;
using SCRP.Web.Models.Advertisement;
using SCRP.Web.Models.Posts;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;

namespace SCRP.Web.Controllers
{
    public class AdvertisementController : Controller
    {

        public DatabaseContext GetDatabaseContext()
        {
            DatabaseContext context = new DatabaseContext();
            context.Configuration.LazyLoadingEnabled = false;
            return context;
        }


        public ActionResult Index()
        {
            DatabaseContext context = GetDatabaseContext();
            AdvertisementListViewModel advertisementListViewModel = new AdvertisementListViewModel();

            List<Post> posts = context.Posts.Include("Pet").Include("Pet.PetType").Include("HelpCampaignDetail").Include("ImagePostMappings").Include("ImagePostMappings.Image")
                .Where(x => x.PostTypeId == 1 && x.IsDeleted == false).OrderByDescending(x => x.Id).ToList();
            List<PetType> petTypes = context.PetTypes.ToList();
            
            foreach( Post post in posts)
            {
                advertisementListViewModel.AdvertisementViewModels.Add(
                new AdvertisementViewModel
                {
                    PetTypeId = post.Pet.PetTypeId,
                    PetType = post.Pet.PetType.Name,
                    MissingCount = posts.Where(x=> x.Pet.PetTypeId == post.Pet.PetTypeId).Count().ToString(),
                    Text = $"These {post.Pet.PetType.Name} are listed as lost on our Lost {post.Pet.PetType.Name} Register",
                    ImagePath = post.ImagePostMappings[0].Image.Path
                });
            }

        
            return View(advertisementListViewModel);
  
        }

        public ActionResult Detail(int petTypeId)
        {
            DatabaseContext context = GetDatabaseContext();
            List<Post> posts = context.Posts.Include("Pet").Include("Pet.PetType").Include("HelpCampaignDetail").Include("ImagePostMappings").Include("ImagePostMappings.Image")
                .Where(x => x.PostTypeId == 1 && x.IsDeleted == false).OrderByDescending(x => x.Id).ToList();
            List<Post> postsfiltered = posts.Where(x => x.Pet.PetTypeId == petTypeId).ToList();
            PostListViewModel postListViewModel = new PostListViewModel();
            postListViewModel.Posts = postsfiltered;
            //var global = HostingEnvironment.ApplicationPhysicalPath;
            //var posts = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Missing && !x.IsDeleted);
            //var pets = _petBLL.GetList();
            //var ımagePostMappingList = _imagePostMappingBLL.GetList();
            //var ımageList = _imageBLL.GetList();

            //PostListViewModel postListViewModel = new PostListViewModel();
            //postListViewModel.Posts = posts.ToList();
            //foreach (var item in postListViewModel.Posts)
            //{
            //    var lastImage = ımagePostMappingList.LastOrDefault(x => x.PostId == item.Id);
            //    var selectedPet = pets.FirstOrDefault(x => x.Id == item.PetId);

            //    if (selectedPet != null)
            //    {
            //        item.Pet = selectedPet;
            //    }

            //    if (lastImage != null)
            //    {
            //        var imageModel = ımageList.FirstOrDefault(x => x.Id == lastImage.ImageId);
            //        if (imageModel != null)
            //        {
            //            imageModel.Path = Path.Combine("/", imageModel.Path);
            //            item.ImagePostMappings = new List<ImagePostMapping>() { new ImagePostMapping() { Image = imageModel } };
            //        }
            //    }
            //    else
            //    {
            //        item.ImagePostMappings = new List<ImagePostMapping>() { new ImagePostMapping() { Image = new Image { Path = Path.Combine("/", "images", "toy-poodle.jpg") } } };
            //    }
            //}

            //var postByPetId = postListViewModel.Posts.Where(x => (int)x.Pet.PetTypeId == petTypeId).ToList();

            //postListViewModel.Posts = postByPetId;

            return View(postListViewModel);
        }

        public ActionResult PetDetail(int? id)
        {
            DatabaseContext context = GetDatabaseContext();
            Post post = context.Posts.Include("Pet").Include("Member").Include("Pet.PetType").Include("HelpCampaignDetail").Include("ImagePostMappings").Include("ImagePostMappings.Image")
                .Where(x => x.Id == id).OrderByDescending(x => x.Id).FirstOrDefault();
            AdvertisementPetViewModel advertisementPetViewModel = new AdvertisementPetViewModel();
            advertisementPetViewModel.Post = post;
            //    if (id.HasValue && id.Value != default) //Detail
            //    {
            //        var post = _postBLL.GetList().FirstOrDefault(x => x.Id == id.Value);
            //        var pets = _petBLL.GetList();
            //        var ımagePostMappingList = _imagePostMappingBLL.GetList();
            //        var ımageList = _imageBLL.GetList();

            //        var member = _memberBLL.GetById(post.MemberId);

            //        AdvertisementPetViewModel advertisementPetViewModel = new AdvertisementPetViewModel();
            //        advertisementPetViewModel.Post = post;

            //        var lastImage = ımagePostMappingList.LastOrDefault(x => x.PostId == advertisementPetViewModel.Post.Id);
            //        var selectedPet = pets.FirstOrDefault(x => x.Id == advertisementPetViewModel.Post.PetId);

            //        if (selectedPet != null)
            //        {
            //            advertisementPetViewModel.Post.Pet = selectedPet;
            //        }

            //        if (member != null)
            //        {
            //            advertisementPetViewModel.Post.Member = member;
            //        }

            //        if (lastImage != null)
            //        {
            //            var imageModel = ımageList.FirstOrDefault(x => x.Id == lastImage.ImageId);
            //            if (imageModel != null)
            //            {
            //                imageModel.Path = Path.Combine("/", imageModel.Path);
            //                advertisementPetViewModel.Post.ImagePostMappings = new List<ImagePostMapping>() { new ImagePostMapping() { Image = imageModel } };
            //            }
            //        }
            //        else
            //        {
            //            advertisementPetViewModel.Post.ImagePostMappings = new List<ImagePostMapping>() { new ImagePostMapping() { Image = new Image { Path = Path.Combine("/", "images", "toy-poodle.jpg") } } };
            //        }

            //    }
            return View(advertisementPetViewModel);
            //else
            //{
            //    return RedirectToAction("Index");
            //}
        }
    }
}