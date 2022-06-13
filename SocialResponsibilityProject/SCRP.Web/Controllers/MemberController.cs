
using SCRP.Foundation.Entities;
using SCRP.Web.Models.Advertisement;
using SCRP.Web.Models.Member;
using SCRP.Web.Models.Posts;
using SCRP.Web.Models.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;

namespace SCRP.Web.Controllers
{
    public class MemberController : Controller
    {
        

        public ActionResult Index()
        {
            // Kullanıcı personal info larını gördüğü yer
            return View();
        }

        public ActionResult MemberInformation()
        {
            //int memberId = AuthorizationCheckMember();
            //if (memberId == default)
            //{
            //    return RedirectToAction("Logout", "User");
            //}

            //UserEditViewModel userEditViewModel = new UserEditViewModel();

            //userEditViewModel.Member = _memberBLL.GetById(memberId);

            //return View(userEditViewModel);
            return View();
        }

        //public ActionResult MemberEdit()
        //{
        //    int memberId = AuthorizationCheckMember();
        //    if (memberId == default)
        //    {
        //        return RedirectToAction("Logout", "User");
        //    }

        //    UserEditViewModel userEditViewModel = new UserEditViewModel();
        //    userEditViewModel.Member = _memberBLL.GetById(memberId);

        //    return View(userEditViewModel);
        //}

        //[HttpPost]
        //public ActionResult MemberEdit(UserEditViewModel userEditViewModel)
        //{
        //    if (userEditViewModel.Member != null)
        //    {
        //        if (Session["Id"] != null)
        //        {
        //            var userId = int.Parse(Session["Id"].ToString());
        //            var member = _memberBLL.GetById(userId);
        //            if (member != null)
        //            {
        //                _memberBLL.Update(userEditViewModel.Member);
        //                Session["FullName"] = $"{userEditViewModel.Member.FirstName} {userEditViewModel.Member.LastName}";
        //            }
        //            else
        //            {
        //                _memberBLL.Insert(userEditViewModel.Member);
        //            }
        //            return RedirectToAction("MemberInformation");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Logout", "User");
        //        }
        //    }

        //    return View();
        //}

        public ActionResult MyAdvertisements()
        {
            //int memberId = AuthorizationCheckMember();
            //if (memberId == default)
            //{
            //    return RedirectToAction("Logout", "User");
            //}

            //var posts = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Missing && !x.IsDeleted && x.MemberId == memberId);

            //PostListViewModel postListViewModel = new PostListViewModel();
            //postListViewModel.Posts = posts.ToList();

            //FillImagePosts(postListViewModel);
            //return View(postListViewModel);
            return View();
        }

        //public ActionResult AdvertisementDetail(int? id)
        //{
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
        //        return View(advertisementPetViewModel);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        //public ActionResult EditAdvertisement(int? id)
        //{
        //    int memberId = AuthorizationCheckMember();
        //    if (memberId == default)
        //    {
        //        return RedirectToAction("Logout", "User");
        //    }

        //    MemberAdvertisementEditViewModel memberAdvertimentEditViewModel = new MemberAdvertisementEditViewModel();
        //    if (id.HasValue && id.Value != default) //Edit
        //    {
        //        var post = _postBLL.GetById(id.Value);
        //        memberAdvertimentEditViewModel.Post = post;

        //        var petId = post.PetId;

        //        var pet = _petBLL.GetById(petId);
        //        memberAdvertimentEditViewModel.Pet = pet;

        //        var ımagePostMapping = _imagePostMappingBLL.GetList().LastOrDefault(x => x.PostId == post.Id);
        //        if (ımagePostMapping != null)
        //        {
        //            memberAdvertimentEditViewModel.Image = _imageBLL.GetById(ımagePostMapping.ImageId);
        //            memberAdvertimentEditViewModel.Image.Path = Path.Combine("/", memberAdvertimentEditViewModel.Image.Path);
        //        }
        //        else
        //        {
        //            memberAdvertimentEditViewModel.Image = new Image() { Path = Path.Combine("/", "images", "toy-poodle.jpg") };
        //        }
        //        memberAdvertimentEditViewModel.Post.MissedDate = DateTime.Now;
        //        return View(memberAdvertimentEditViewModel);
        //    }
        //    else
        //    {
        //        memberAdvertimentEditViewModel.Pet = new Pet();
        //        memberAdvertimentEditViewModel.Post = new Post();
        //        memberAdvertimentEditViewModel.Image = new Image();
        //        memberAdvertimentEditViewModel.Post.MissedDate = DateTime.Now;
        //        return View(memberAdvertimentEditViewModel);
        //    }
        //}

        [HttpPost]
        public ActionResult EditAdvertisement(MemberAdvertisementEditViewModel advertimentViewModel)
        {
            //int memberId = AuthorizationCheckMember();
            //if (memberId == default)
            //{
            //    return RedirectToAction("Logout", "User");
            //}

            //if (advertimentViewModel.Pet != null && advertimentViewModel.Post != null)
            //{
            //    advertimentViewModel.Post.PostTypeId = Foundation.Enums.PostTypes.Missing;
            //    advertimentViewModel.Post.MemberId = memberId;
            //    advertimentViewModel.Post.CompletedDate = DateTime.Now.AddDays(10);

            //    if (!CheckModelState())
            //    {
            //        advertimentViewModel.Post.MissedDate = DateTime.Now;
            //        advertimentViewModel.Image = new Image();
            //        return View(advertimentViewModel);
            //    }

            //    if (advertimentViewModel.Pet.Id != default) //edit
            //    {
            //        var pet = _petBLL.GetList().FirstOrDefault(x => x.Id == advertimentViewModel.Pet.Id);

            //        if (pet != null)
            //        {
            //            _petBLL.Update(advertimentViewModel.Pet);
            //        }
            //    }
            //    else
            //    {
            //        _petBLL.Insert(advertimentViewModel.Pet);
            //    }

            //    advertimentViewModel.Post.PetId = advertimentViewModel.Pet.Id;


            //    if (advertimentViewModel.Post.Id != default) //edit
            //    {
            //        var post = _postBLL.GetList().FirstOrDefault(x => x.Id == advertimentViewModel.Post.Id);
            //        if (post != null)
            //        {
            //            _postBLL.Update(advertimentViewModel.Post);
            //        }
            //    }
            //    else
            //    {
            //        _postBLL.Insert(advertimentViewModel.Post);
            //    }

            //    if (advertimentViewModel.ImageFile != null)
            //    {
            //        //Image Upload
            //        var global = HostingEnvironment.ApplicationPhysicalPath;
            //        string FileName = Path.GetFileNameWithoutExtension(advertimentViewModel.ImageFile.FileName);
            //        string FileExtension = Path.GetExtension(advertimentViewModel.ImageFile.FileName);
            //        FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
            //        advertimentViewModel.Image = new Image { Path = Path.Combine("images", FileName) };
            //        advertimentViewModel.ImageFile.SaveAs(Path.Combine(global, advertimentViewModel.Image.Path));

            //        var postModelId = advertimentViewModel.Post.Id;
            //        advertimentViewModel.Image.ImagePostMappings = new List<ImagePostMapping>() { new ImagePostMapping { PostId = postModelId } };

            //        _imageBLL.Insert(advertimentViewModel.Image);
            //    }
            //}


            return RedirectToAction("MyAdvertisements");
        }

        public ActionResult MyPetsFound()
        {
            //int memberId = AuthorizationCheckMember();
            //if (memberId == default)
            //{
            //    return RedirectToAction("Logout", "User");
            //}

            //var posts = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Missing && x.IsFounded == true && !x.IsDeleted && memberId == x.MemberId);

            //PostListViewModel postListViewModel = new PostListViewModel();
            //postListViewModel.Posts = posts.ToList();
            //FillImagePosts(postListViewModel);
            //return View(postListViewModel);
            return View();
        }

        public ActionResult FoundAdvertisement(int id)
        {
            //int memberId = AuthorizationCheckMember();
            //if (memberId == default)
            //{
            //    return RedirectToAction("Logout", "User");
            //}

            //var postModel = _postBLL.GetById(id);

            //if (postModel != null)
            //{
            //    postModel.IsFounded = true;
            //    _postBLL.Update(postModel);
            //}

            //return RedirectToAction("MyPetsFound");
            return View();
        }

        //public ActionResult DeleteAdvertisement(int id)
        //{
        //    int memberId = AuthorizationCheckMember();
        //    if (memberId == default)
        //    {
        //        return RedirectToAction("Logout", "User");
        //    }

        //    var postModel = _postBLL.GetById(id);

        //    if (postModel != null)
        //    {
        //        postModel.IsDeleted = true;
        //        _postBLL.Update(postModel);
        //    }

        //    return RedirectToAction("MyAdvertisements");
        //}

        //private void FillImagePosts(PostListViewModel postListViewModel)
        //{
        //    var ımagePostMappingList = _imagePostMappingBLL.GetList();
        //    var ımageList = _imageBLL.GetList();

        //    foreach (var item in postListViewModel.Posts)
        //    {
        //        var lastImage = ımagePostMappingList.LastOrDefault(x => x.PostId == item.Id);

        //        if (lastImage != null)
        //        {
        //            var imageModel = ımageList.FirstOrDefault(x => x.Id == lastImage.ImageId);
        //            if (imageModel != null)
        //            {
        //                imageModel.Path = Path.Combine("/", imageModel.Path);
        //                item.ImagePostMappings = new List<ImagePostMapping>() { new ImagePostMapping() { Image = imageModel } };
        //            }
        //        }
        //        else
        //        {
        //            item.ImagePostMappings = new List<ImagePostMapping>() { new ImagePostMapping() { Image = new Image { Path = Path.Combine("/", "images", "toy-poodle.jpg") } } };
        //        }
        //    }
        //}

        //private int AuthorizationCheckMember()
        //{
        //    int memberId = 0;
        //    if (Session["Id"] != null)
        //    {
        //        var userId = int.Parse(Session["Id"].ToString());
        //        var member = _memberBLL.GetById(userId);
        //        if (member != null)
        //        {
        //            memberId = member.Id;
        //        }
        //    }
        //    return memberId;
        //}

        private bool CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                string errors = "";
                var errorList = ModelState.Values.Select(x => x.Errors).Where(x => x.Count > 0).SelectMany(x => x).Select(x => x.ErrorMessage);

                foreach (var item in errorList)
                {
                    errors += item + " ,";
                }

                TempData["CssClassName"] = "danger";
                TempData["Message"] = "Saving error !, Errors: " + errors;

                return false;
            }
            return true;
        }
    }
}