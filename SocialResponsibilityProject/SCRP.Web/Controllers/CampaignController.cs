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

    public class CampaignController : Controller
    {
        

        public ActionResult Index()
        {
            //var campaignPosts = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Campaign && !x.IsDeleted).ToList();

            //foreach (var item in campaignPosts)
            //{
            //    var helpCampaignDetailId = item.HelpCampaignDetailId;
            //    if (helpCampaignDetailId.HasValue && helpCampaignDetailId.Value != default)
            //    {
            //        var helpCampaignDetail = _helpCampaignDetailBLL.GetById(helpCampaignDetailId.Value);

            //        item.HelpCampaignDetail = helpCampaignDetail;
            //    }
            //}

            //var posts = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Campaign && !x.IsDeleted);
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

            //        if (post.MemberId == AuthorizationCheckMember())
            //        {
            //            memberAdvertimentEditViewModel.MemberId = -1;
            //        }
            //        else
            //        {
            //            memberAdvertimentEditViewModel.MemberId = AuthorizationCheckMember();
            //        }

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

            //        memberAdvertimentEditViewModel.PostId = post.Id;
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

            return View();
        }

        [HttpPost]
        public ActionResult Detail(MemberCampaignEditViewModel memberCampaignEditViewModel)
        {
            //int memberId = AuthorizationCheckMember();
            //if (memberId == default)
            //{
            //    return View();
            //}

            //if (!string.IsNullOrEmpty(memberCampaignEditViewModel.CampaignUserDonationValue.ToString()))
            //{
            //    MemberHelpCampaignMapping helpCampaignDetail = new MemberHelpCampaignMapping();

            //    helpCampaignDetail.MemberId = memberId;
            //    helpCampaignDetail.PostId = memberCampaignEditViewModel.PostId;
            //    helpCampaignDetail.MemberVerify = true;
            //    helpCampaignDetail.CampaignValue = memberCampaignEditViewModel.CampaignUserDonationValue;
            //    helpCampaignDetail.HelpCampaignDetailId = memberCampaignEditViewModel.HelpCampaignDetail.Id;

            //    var result = _memberHelpCampaignMappingBLL.Insert(helpCampaignDetail);

            //    TempData["CssClassName"] = "success";
            //    TempData["Message"] = "Request Created ";
            //}

            //return RedirectToAction("Index");
            return View();
        }

        private int AuthorizationCheckMember()
        {
            int memberId = 0;
            //if (Session["Id"] != null)
            //{
            //    var userId = int.Parse(Session["Id"].ToString());
            //    var member = _memberBLL.GetById(userId);
            //    if (member != null)
            //    {
            //        memberId = member.Id;
            //    }
            //}

            return memberId;
        }
    }
}