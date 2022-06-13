using SCRP.Foundation.Entities;

using SCRP.Web.Models.MemberHelpCampaign;
using System;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Collections.Generic;
using SCRP.Web.Models.Posts;

namespace SCRP.Web.Controllers
{
    public class MemberCampaignController : Controller
    {
        
        public ActionResult Index()
        {
            //int memberId = AuthorizationCheckMember();
            //if (memberId == default)
            //{
            //    return RedirectToAction("Logout", "User");
            //}

            //var campaignPosts = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Campaign && memberId == x.MemberId && !x.IsDeleted).ToList();

            //foreach (var item in campaignPosts)
            //{
            //    var helpCampaignDetailId = item.HelpCampaignDetailId;
            //    if (helpCampaignDetailId.HasValue && helpCampaignDetailId.Value != default)
            //    {
            //        var helpCampaignDetail = _helpCampaignDetailBLL.GetById(helpCampaignDetailId.Value);

            //        item.HelpCampaignDetail = helpCampaignDetail;
            //    }
            //}

            //var posts = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Campaign && !x.IsDeleted && x.MemberId == memberId);
            //var ımagePostMappingList = _imagePostMappingBLL.GetList();
            //var ımageList = _imageBLL.GetList();

            //PostListViewModel postListViewModel = new PostListViewModel();
            //postListViewModel.Posts = campaignPosts;
            //foreach (var item in postListViewModel.Posts)
            //{
            //    var lastImage = ımagePostMappingList.LastOrDefault(x => x.PostId == item.Id);

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

            //return View(postListViewModel);
            return View();
        }

        public ActionResult Detail(int? id)
        {
            //MemberCampaignEditViewModel memberAdvertimentEditViewModel = new MemberCampaignEditViewModel();
            //if (id.HasValue && id.Value != default) //Edit
            //{
            //    var post = _postBLL.GetById(id.Value);
            //    memberAdvertimentEditViewModel.Post = post;
            //    if (post.HelpCampaignDetailId.HasValue && post.HelpCampaignDetailId.Value != default) //Edit
            //    {
            //        var petId = post.PetId;
            //        var pet = _petBLL.GetById(petId);
            //        memberAdvertimentEditViewModel.Pet = pet;

            //        var helpCampaingId = post.HelpCampaignDetailId;
            //        var helpCampaing = _helpCampaignDetailBLL.GetById(helpCampaingId.Value);
            //        if (helpCampaing != null)
            //        {
            //            memberAdvertimentEditViewModel.HelpCampaignDetail = helpCampaing;
            //        }
            //        else
            //        {
            //            memberAdvertimentEditViewModel.HelpCampaignDetail = new HelpCampaignDetail();
            //        }

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

            //        return View(memberAdvertimentEditViewModel);
            //    }
            //}
            //else
            //{
            //    memberAdvertimentEditViewModel.Pet = new Pet();
            //    memberAdvertimentEditViewModel.Post = new Post();
            //    memberAdvertimentEditViewModel.Image = new Image();
            //    memberAdvertimentEditViewModel.HelpCampaignDetail = new HelpCampaignDetail();
            //    return View(memberAdvertimentEditViewModel);
            //}

            //return View();
            return View();
        }

        public ActionResult FinishedCampaigns()
        {
            //int memberId = AuthorizationCheckMember();
            //if (memberId == default)
            //{
            //    return RedirectToAction("Logout", "User");
            //}

            //var posts = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Campaign && !x.IsDeleted && x.MemberId == memberId && x.IsFounded);

            //foreach (var item in posts)
            //{
            //    var helpCampaignDetailId = item.HelpCampaignDetailId;
            //    if (helpCampaignDetailId.HasValue && helpCampaignDetailId.Value != default)
            //    {
            //        var helpCampaignDetail = _helpCampaignDetailBLL.GetById(helpCampaignDetailId.Value);

            //        item.HelpCampaignDetail = helpCampaignDetail;
            //    }
            //}

            //PostListViewModel postListViewModel = new PostListViewModel();
            //postListViewModel.Posts = posts.ToList();

            //FillImagePosts(postListViewModel);

            //return View(postListViewModel);
            return View();
        }

        public ActionResult WaitingForAuthor()
        {
            //int memberId = AuthorizationCheckMember();
            //if (memberId == default)
            //{
            //    return RedirectToAction("Logout", "User");
            //}
            //MemberCampaignListViewModel memberCampaignListViewModel = new MemberCampaignListViewModel();

            //var memberCampaigns = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Campaign && !x.IsDeleted && x.MemberId == memberId);
            //var postIds = memberCampaigns.Select(x => x.Id).ToList();
            //var memberHelps = _memberHelpCampaignMappingBLL.GetList().Where(x => x.PostId.HasValue && x.PostId.Value != 0 && postIds.Contains(x.PostId.Value));

            //PostListViewModel postListViewModel = new PostListViewModel();

            //HelpCampaignViewModel helpCampaignViewModel = new HelpCampaignViewModel();

            //helpCampaignViewModel.HelpCampaignMappings = memberHelps.ToList();
            //memberCampaignListViewModel.MemberCampaignListViewModels = new List<MemberCampaignViewModel>();
            //foreach (var item in helpCampaignViewModel.HelpCampaignMappings)
            //{
            //    MemberCampaignViewModel memberCampaignViewModel = new MemberCampaignViewModel();
            //    if (item.PostId.HasValue && item.PostId.Value != 0)
            //    {
            //        Post post = _postBLL.GetById(item.PostId.Value);
            //        Pet pet = _petBLL.GetById(post.PetId);
            //        Member member = _memberBLL.GetById(item.MemberId);

            //        if (pet != null && post != null && member != null)
            //        {
            //            memberCampaignViewModel = new MemberCampaignViewModel()
            //            {
            //                PostId = post.Id,
            //                CampaignTitle = post.Title,
            //                Pet = pet.Name,
            //                DonationMember = $"{member.FirstName} { member.LastName }",
            //                DonationIban = member.IBAN,
            //                DonationValue = item.CampaignValue.ToString(),
            //                ApprovedByOwner = item.AdminVerify,
            //                MemberHelpCampaignId = item.Id,
            //            };
            //        }

            //        var ımagePostMapping = _imagePostMappingBLL.GetList().LastOrDefault(x => x.PostId == post.Id);
            //        if (ımagePostMapping != null)
            //        {
            //            memberCampaignViewModel.Image = _imageBLL.GetById(ımagePostMapping.ImageId).Path;
            //        }
            //        else
            //        {
            //            memberCampaignViewModel.Image = Path.Combine("/", "images", "toy-poodle.jpg");
            //        }
            //    }


            //    memberCampaignListViewModel.MemberCampaignListViewModels.Add(memberCampaignViewModel);
            //}

            //return View(memberCampaignListViewModel);
            return View();
        }

        public ActionResult ApproveCampaign(int id, string value, int memberHelpId)
        {
            //int memberId = AuthorizationCheckMember();
            //if (memberId == default)
            //{
            //    return RedirectToAction("Logout", "User");
            //}

            //var post = _postBLL.GetById(id);
            //var helpCampId = post.HelpCampaignDetailId;
            //var helpCamp = _helpCampaignDetailBLL.GetById(helpCampId.Value);
            //helpCamp.CollectedAmount += decimal.Parse(value);
            //_helpCampaignDetailBLL.Update(helpCamp);
            //var memberHelpCampaignMapping = _memberHelpCampaignMappingBLL.GetById(memberHelpId);

            //memberHelpCampaignMapping.AdminVerify = true;
            //_memberHelpCampaignMappingBLL.Update(memberHelpCampaignMapping);

            //return RedirectToAction("WaitingForAuthor");
            return View();
        }

        public ActionResult Edit(int? id)
        {
            //int memberId = AuthorizationCheckMember();
            //if (memberId == default)
            //{
            //    return RedirectToAction("Logout", "User");
            //}

            //MemberCampaignEditViewModel memberAdvertimentEditViewModel = new MemberCampaignEditViewModel();
            //if (id.HasValue && id.Value != default) //Edit
            //{
            //    var post = _postBLL.GetById(id.Value);
            //    memberAdvertimentEditViewModel.Post = post;
            //    if (post.HelpCampaignDetailId.HasValue && post.HelpCampaignDetailId.Value != default) //Edit
            //    {
            //        var petId = post.PetId;
            //        var pet = _petBLL.GetById(petId);
            //        memberAdvertimentEditViewModel.Pet = pet;

            //        var helpCampaingId = post.HelpCampaignDetailId;
            //        var helpCampaing = _helpCampaignDetailBLL.GetById(helpCampaingId.Value);
            //        if (helpCampaing != null)
            //        {
            //            memberAdvertimentEditViewModel.HelpCampaignDetail = helpCampaing;
            //        }
            //        else
            //        {
            //            memberAdvertimentEditViewModel.HelpCampaignDetail = new HelpCampaignDetail();
            //        }

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

            //        return View(memberAdvertimentEditViewModel);
            //    }
            //}
            //else
            //{
            //    memberAdvertimentEditViewModel.Pet = new Pet();
            //    memberAdvertimentEditViewModel.Post = new Post();
            //    memberAdvertimentEditViewModel.Image = new Image();
            //    memberAdvertimentEditViewModel.HelpCampaignDetail = new HelpCampaignDetail();
            //    memberAdvertimentEditViewModel.Post.CompletedDate = DateTime.Now;
            //    return View(memberAdvertimentEditViewModel);
            //}

            return View();
        }

        [HttpPost]
        public ActionResult Edit(MemberCampaignEditViewModel memberCampaignEditViewModel)
        {
            //int memberId = AuthorizationCheckMember();
            //if (memberId == default)
            //{
            //    return RedirectToAction("Logout", "User");
            //}
            //if (memberCampaignEditViewModel.Pet != null && memberCampaignEditViewModel.Post != null && memberCampaignEditViewModel.HelpCampaignDetail != null)
            //{
            //    memberCampaignEditViewModel.Post.PostTypeId = Foundation.Enums.PostTypes.Campaign;

            //    if (!CheckModelState())
            //    {
            //        return View(memberCampaignEditViewModel);
            //    }


            //    memberCampaignEditViewModel.Post.MemberId = memberId;

            //    memberCampaignEditViewModel.Post.MissedDate = DateTime.Now;

            //    if (memberCampaignEditViewModel.Pet.Id != default) //edit
            //    {
            //        var pet = _petBLL.GetList().FirstOrDefault(x => x.Id == memberCampaignEditViewModel.Pet.Id);

            //        if (pet != null)
            //        {
            //            _petBLL.Update(memberCampaignEditViewModel.Pet);
            //        }
            //    }
            //    else
            //    {
            //        _petBLL.Insert(memberCampaignEditViewModel.Pet);
            //    }

            //    if (memberCampaignEditViewModel.HelpCampaignDetail.Id != default) //edit
            //    {
            //        var helpCampaignDetail = _helpCampaignDetailBLL.GetList().FirstOrDefault(x => x.Id == memberCampaignEditViewModel.HelpCampaignDetail.Id);

            //        if (helpCampaignDetail != null)
            //        {
            //            _helpCampaignDetailBLL.Update(memberCampaignEditViewModel.HelpCampaignDetail);
            //        }
            //    }
            //    else
            //    {
            //        _helpCampaignDetailBLL.Insert(memberCampaignEditViewModel.HelpCampaignDetail);
            //    }

            //    memberCampaignEditViewModel.Post.PetId = memberCampaignEditViewModel.Pet.Id;
            //    memberCampaignEditViewModel.Post.HelpCampaignDetailId = memberCampaignEditViewModel.HelpCampaignDetail.Id;

            //    if (memberCampaignEditViewModel.Post.Id != default) //edit
            //    {
            //        var post = _postBLL.GetList().FirstOrDefault(x => x.Id == memberCampaignEditViewModel.Post.Id);
            //        if (post != null)
            //        {
            //            _postBLL.Update(memberCampaignEditViewModel.Post);
            //        }
            //    }
            //    else
            //    {
            //        _postBLL.Insert(memberCampaignEditViewModel.Post);
            //    }

            //    if (memberCampaignEditViewModel.ImageFile != null)
            //    {
            //        //Image Upload
            //        var global = HostingEnvironment.ApplicationPhysicalPath;
            //        string FileName = Path.GetFileNameWithoutExtension(memberCampaignEditViewModel.ImageFile.FileName);
            //        string FileExtension = Path.GetExtension(memberCampaignEditViewModel.ImageFile.FileName);
            //        FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
            //        memberCampaignEditViewModel.Image = new Image { Path = Path.Combine("images", FileName) };
            //        memberCampaignEditViewModel.ImageFile.SaveAs(Path.Combine(global, memberCampaignEditViewModel.Image.Path));

            //        var postModelId = memberCampaignEditViewModel.Post.Id;
            //        memberCampaignEditViewModel.Image.ImagePostMappings = new List<ImagePostMapping>() { new ImagePostMapping { PostId = postModelId } };

            //        _imageBLL.Insert(memberCampaignEditViewModel.Image);
            //    }
            //}

            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int id)
        //{
        //    if (id != default)
        //    {
        //        var postModel = _postBLL.GetById(id);
        //        if (postModel != null && Session["Id"] != null)
        //        {
        //            var userId = int.Parse(Session["Id"].ToString());
        //            var member = _memberBLL.GetById(userId);
        //            if (member != null)
        //            {
        //                postModel.IsDeleted = true;
        //                _postBLL.Update(postModel);
        //            }
        //        }
        //    }

        //    return RedirectToAction("MyAdvertisements");
        //}

        //public ActionResult DeleteCampaign(int id)
        //{
        //    if (id != default)
        //    {
        //        var postModel = _postBLL.GetById(id);
        //        if (postModel != null && Session["Id"] != null)
        //        {
        //            var userId = int.Parse(Session["Id"].ToString());
        //            var member = _memberBLL.GetById(userId);
        //            if (member != null)
        //            {
        //                postModel.IsDeleted = true;
        //                _postBLL.Update(postModel);
        //            }
        //        }
        //    }

        //    return RedirectToAction("Index");
        //}

        //public ActionResult CompleteCampaign(int id)
        //{
        //    if (id != default)
        //    {
        //        var postModel = _postBLL.GetById(id);
        //        if (postModel != null && Session["Id"] != null)
        //        {
        //            var userId = int.Parse(Session["Id"].ToString());
        //            var member = _memberBLL.GetById(userId);
        //            if (member != null)
        //            {
        //                postModel.IsFounded = true;
        //                _postBLL.Update(postModel);
        //            }
        //        }
        //    }

        //    return RedirectToAction("FinishedCampaigns");
        //}

        //#region Methods
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


