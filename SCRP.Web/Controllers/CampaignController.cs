using SCRP.Foundation.Entities;
using SCRP.Web.Models.MemberHelpCampaign;
using System;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Collections.Generic;
using SCRP.Web.Models.Posts;
using SCRP.DAL.EF;

namespace SCRP.Web.Controllers
{

    public class CampaignController : Controller
    {

        public DatabaseContext GetDatabaseContext()
        {
            DatabaseContext context = new DatabaseContext();
            context.Configuration.LazyLoadingEnabled = false;
            return context;
        }

        public ActionResult Index()
        {
            var context = GetDatabaseContext();
            

            //var campaignPosts = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Campaign && memberId == x.MemberId && !x.IsDeleted).ToList();
            var campaignPosts = context.Posts.Include("ImagePostMappings").Include("ImagePostMappings.Image")
                .Where(x => x.PostTypeId == 2 && !x.IsDeleted).ToList();

            foreach (var item in campaignPosts)
            {
                var helpCampaignDetailId = item.HelpCampaignDetailId;
                if (helpCampaignDetailId != 0)
                {
                    //var helpCampaignDetail = _helpCampaignDetailBLL.GetById(helpCampaignDetailId.Value);
                    var helpCampaignDetail = context.HelpCampaignDetails.Where(x => x.Id == helpCampaignDetailId).FirstOrDefault();
                    item.HelpCampaignDetail = helpCampaignDetail;
                }
            }

            //var ımagePostMappingList = _imagePostMappingBLL.GetList();
            //var ımageList = _imageBLL.GetList();

            PostListViewModel postListViewModel = new PostListViewModel();
            postListViewModel.Posts = campaignPosts;
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

            return View(postListViewModel);




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
            //return View();
        }

        public ActionResult Detail(int? id)
        {
            var context = GetDatabaseContext();
            MemberCampaignEditViewModel memberAdvertimentEditViewModel = new MemberCampaignEditViewModel();
            if (id.HasValue && id.Value != default) //Edit
            {
                if(Session.Keys.Count > 0)
                {
                    memberAdvertimentEditViewModel.MemberId = Convert.ToInt32(Session["ID"]);
                }
                //var post = _postBLL.GetById(id.Value);
                Post post = context.Posts.Include("Member").Include("HelpCampaignDetail")
                    .Include("Pet").Include("ImagePostMappings").Include("ImagePostMappings.Image")
                   .Where(x => x.Id == id).FirstOrDefault();
                memberAdvertimentEditViewModel.Post = post;
                if (post.HelpCampaignDetailId != default) //Edit
                {
                    memberAdvertimentEditViewModel.HelpCampaignDetail = post.HelpCampaignDetail;
                    memberAdvertimentEditViewModel.Pet = post.Pet;
                    memberAdvertimentEditViewModel.PetType = (post.Pet.PetTypeId == 1 ? "Dog" : "Cat");
                    memberAdvertimentEditViewModel.Image = post.ImagePostMappings[0].Image;
                    memberAdvertimentEditViewModel.CampaignUserDonationValue = post.HelpCampaignDetail.CollectedAmount;
                    memberAdvertimentEditViewModel.Post = post;
                    return View(memberAdvertimentEditViewModel);
                }
            }
            else
            {
                memberAdvertimentEditViewModel.Pet = new Pet();
                memberAdvertimentEditViewModel.Post = new Post();
                memberAdvertimentEditViewModel.Image = new Image();
                memberAdvertimentEditViewModel.HelpCampaignDetail = new HelpCampaignDetail();
                return View(memberAdvertimentEditViewModel);
            }
            return View(memberAdvertimentEditViewModel);
        }

        [HttpPost]
        public ActionResult Detail(MemberCampaignEditViewModel memberCampaignEditViewModel)
        {
            if (Session["ID"] == "null")
            {
                return RedirectToAction("Logout", "User");
            }
            int memberId = Convert.ToInt32(Session["ID"]);

            if (!string.IsNullOrEmpty(memberCampaignEditViewModel.CampaignUserDonationValue.ToString()))
            {
                MemberHelpCampaignMapping helpCampaignDetail = new MemberHelpCampaignMapping();

                helpCampaignDetail.MemberId = memberId;
                //helpCampaignDetail.PostId = memberCampaignEditViewModel.PostId;
                helpCampaignDetail.MemberVerify = true;
                helpCampaignDetail.CampaignValue = memberCampaignEditViewModel.CampaignUserDonationValue;
                helpCampaignDetail.HelpCampaignDetailId = memberCampaignEditViewModel.HelpCampaignDetail.Id;

                //var result = _memberHelpCampaignMappingBLL.Insert(helpCampaignDetail);

                TempData["CssClassName"] = "success";
                TempData["Message"] = "Request Created ";
            }

            return RedirectToAction("Index");
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