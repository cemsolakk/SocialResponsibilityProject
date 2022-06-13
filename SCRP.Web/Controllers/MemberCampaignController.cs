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
    public class MemberCampaignController : Controller
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
            if (Session["ID"].ToString() == "null")
            {
                return RedirectToAction("Logout", "User");
            }
            int memberId = Convert.ToInt32(Session["ID"]);
            Member member = context.Members.Where(x => x.Id == memberId).FirstOrDefault();

            //var campaignPosts = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Campaign && memberId == x.MemberId && !x.IsDeleted).ToList();
            var campaignPosts = context.Posts.Include("ImagePostMappings").Include("ImagePostMappings.Image")
                .Where(x => x.PostTypeId == 2 && memberId == member.Id && !x.IsDeleted).ToList();

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
            //return View();
        }

        public ActionResult Detail(int? id)
        {
            var context = GetDatabaseContext();
            //if (Session["ID"].ToString() == "null")
            //{
            //    return RedirectToAction("Logout", "User");
            //}
            //int memberId = Convert.ToInt32(Session["ID"]);
            MemberCampaignEditViewModel memberAdvertimentEditViewModel = new MemberCampaignEditViewModel();
            if (id.HasValue && id.Value != default) //Edit
            {
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

            //return View();
            return View();
        }

        public ActionResult FinishedCampaigns()
        {
            var context = GetDatabaseContext();
            if (Session["ID"].ToString() == "null")
            {
                return RedirectToAction("Logout", "User");
            }
            int memberId = Convert.ToInt32(Session["ID"]);
            Member member = context.Members.Where(x => x.Id == memberId).FirstOrDefault();

            //var posts = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Campaign && !x.IsDeleted && x.MemberId == memberId && x.IsFounded);
            var posts = context.Posts.Include("ImagePostMappings").Include("ImagePostMappings.Image")
                .Where(x => x.PostTypeId == 2 && memberId == member.Id && !x.IsDeleted && x.IsFounded).ToList();

            foreach (var item in posts)
            {
                var helpCampaignDetailId = item.HelpCampaignDetailId;
                if (helpCampaignDetailId != default)
                {
                    //var helpCampaignDetail = _helpCampaignDetailBLL.GetById(helpCampaignDetailId.Value);
                    var helpCampaignDetail = context.HelpCampaignDetails.Where(x => x.Id == helpCampaignDetailId).FirstOrDefault();
                    item.HelpCampaignDetail = helpCampaignDetail;
                }
            }

            PostListViewModel postListViewModel = new PostListViewModel();
            postListViewModel.Posts = posts;

            //FillImagePosts(postListViewModel);

            return View(postListViewModel);
        }

        //public ActionResult WaitingForAuthor()
        //{
        //    var context = GetDatabaseContext();
        //    if (Session["ID"].ToString() == "null")
        //    {
        //        return RedirectToAction("Logout", "User");
        //    }
        //    int memberId = Convert.ToInt32(Session["ID"]);
        //    Member member = context.Members.Where(x => x.Id == memberId).FirstOrDefault();

        //    //var memberCampaigns = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Campaign && !x.IsDeleted && x.MemberId == memberId);
        //    var memberCampaigns = context.Posts.Include("ImagePostMappings").Include("ImagePostMappings.Image")
        //        .Where(x => x.PostTypeId == 2 && memberId == member.Id && !x.IsDeleted).ToList();
            
        //    var postIds = memberCampaigns.Select(x => x.Id).ToList();


        //    //var memberHelps = _memberHelpCampaignMappingBLL.GetList().Where(x => x.PostId.HasValue && x.PostId.Value != 0 && postIds.Contains(x.PostId.Value));
        //    var memberHelps = context.MemberHelpCampaignMappings


        //    PostListViewModel postListViewModel = new PostListViewModel();

        //    HelpCampaignViewModel helpCampaignViewModel = new HelpCampaignViewModel();

        //    helpCampaignViewModel.HelpCampaignMappings = memberHelps.ToList();
        //    memberCampaignListViewModel.MemberCampaignListViewModels = new List<MemberCampaignViewModel>();
        //    foreach (var item in helpCampaignViewModel.HelpCampaignMappings)
        //    {
        //        MemberCampaignViewModel memberCampaignViewModel = new MemberCampaignViewModel();
        //        if (item.PostId.HasValue && item.PostId.Value != 0)
        //        {
        //            Post post = _postBLL.GetById(item.PostId.Value);
        //            Pet pet = _petBLL.GetById(post.PetId);
        //            Member member = _memberBLL.GetById(item.MemberId);

        //            if (pet != null && post != null && member != null)
        //            {
        //                memberCampaignViewModel = new MemberCampaignViewModel()
        //                {
        //                    PostId = post.Id,
        //                    CampaignTitle = post.Title,
        //                    Pet = pet.Name,
        //                    DonationMember = $"{member.FirstName} { member.LastName }",
        //                    DonationIban = member.IBAN,
        //                    DonationValue = item.CampaignValue.ToString(),
        //                    ApprovedByOwner = item.AdminVerify,
        //                    MemberHelpCampaignId = item.Id,
        //                };
        //            }

        //            var ımagePostMapping = _imagePostMappingBLL.GetList().LastOrDefault(x => x.PostId == post.Id);
        //            if (ımagePostMapping != null)
        //            {
        //                memberCampaignViewModel.Image = _imageBLL.GetById(ımagePostMapping.ImageId).Path;
        //            }
        //            else
        //            {
        //                memberCampaignViewModel.Image = Path.Combine("/", "images", "toy-poodle.jpg");
        //            }
        //        }


        //        memberCampaignListViewModel.MemberCampaignListViewModels.Add(memberCampaignViewModel);
        //    }

        //    return View(memberCampaignListViewModel);
        //    return View();
        //}

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
            var context = GetDatabaseContext();
            if (Session["ID"].ToString() == "null")
            {
                return RedirectToAction("Logout", "User");
            }
            int memberId = Convert.ToInt32(Session["ID"]);

            MemberCampaignEditViewModel memberCampaignEditViewModel = new MemberCampaignEditViewModel();
            if (id.HasValue && id.Value != default) //Edit
            {
                var post = context.Posts.Where(x => x.Id == id).FirstOrDefault();
                memberCampaignEditViewModel.Post = post;

                if (post.HelpCampaignDetailId != 0) //Edit
                {
                    int petId = post.PetId;
                    Pet pet = context.Pets.Where(x => x.Id == petId).FirstOrDefault();
                    memberCampaignEditViewModel.Pet = pet;

                    var helpCampaingId = post.HelpCampaignDetailId;
                    var helpCampaing = context.HelpCampaignDetails.Where(x => x.Id == helpCampaingId).FirstOrDefault();
                    if (helpCampaing != null)
                    {
                        memberCampaignEditViewModel.HelpCampaignDetail = helpCampaing;
                    }
                    else
                    {
                        memberCampaignEditViewModel.HelpCampaignDetail = new HelpCampaignDetail();
                    }

                    var imagePostMapping = context.ImagePostMappings.Include("Image").Where(x => x.PostId == post.Id).FirstOrDefault();
                    if (imagePostMapping != null)
                    {
                        memberCampaignEditViewModel.Image = imagePostMapping.Image;
                        //memberAdvertimentEditViewModel.Image.Path = Path.Combine("/", memberAdvertimentEditViewModel.Image.Path);
                    }
                    else
                    {
                        memberCampaignEditViewModel.Image = new Image() { Path = Path.Combine("/", "images", "toy-poodle.jpg") };
                    }
                    memberCampaignEditViewModel.Post.MissedDate = DateTime.Now;
                    return View(memberCampaignEditViewModel);
;
                }
            }
            else
            {
                memberCampaignEditViewModel.Pet = new Pet();
                memberCampaignEditViewModel.Post = new Post();
                memberCampaignEditViewModel.Image = new Image();
                memberCampaignEditViewModel.HelpCampaignDetail = new HelpCampaignDetail();
                memberCampaignEditViewModel.Post.MissedDate = DateTime.Now;
                memberCampaignEditViewModel.HelpCampaignDetail.CreatedOn = DateTime.Now;
                memberCampaignEditViewModel.Post.CompletedDate = DateTime.Now.AddDays(20);
                return View(memberCampaignEditViewModel);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(MemberCampaignEditViewModel memberCampaignEditViewModel)
        {
            var context = GetDatabaseContext();
            if (Session["ID"].ToString() == "null")
            {
                return RedirectToAction("Logout", "User");
            }

            int _petTypeId = 0;
            if (memberCampaignEditViewModel.PetType == "Cat")
            {
                _petTypeId = 2;
            }
            else
            {
                _petTypeId = 1;
            }

            int memberId = Convert.ToInt32(Session["ID"]);
            if (memberCampaignEditViewModel.Pet != null && memberCampaignEditViewModel.Post != null && memberCampaignEditViewModel.HelpCampaignDetail != null)
            {
                memberCampaignEditViewModel.Post.PostTypeId = 2;
                int petId = memberCampaignEditViewModel.Pet.Id;
                memberCampaignEditViewModel.Post.MemberId = memberId;
                memberCampaignEditViewModel.Post.CompletedDate = DateTime.Now.AddDays(10);
                memberCampaignEditViewModel.Post.MissedDate = DateTime.Now;

                if (!CheckModelState())
                {
                    return View(memberCampaignEditViewModel);
                }


                

                if (memberCampaignEditViewModel.Pet.Id != default) //edit
                {
                    //var pet = _petBLL.GetList().FirstOrDefault(x => x.Id == memberCampaignEditViewModel.Pet.Id);

                    //if (pet != null)
                    //{
                    //    _petBLL.Update(memberCampaignEditViewModel.Pet);
                    //}
                    var pet = context.Pets.Where(x => x.Id == memberCampaignEditViewModel.Pet.Id).FirstOrDefault();

                    if (pet != null)
                    {
                        pet.Age = memberCampaignEditViewModel.Pet.Age;
                        pet.Color = memberCampaignEditViewModel.Pet.Color;
                        pet.Height = memberCampaignEditViewModel.Pet.Height;
                        pet.IsFounded = memberCampaignEditViewModel.Pet.IsFounded;
                        pet.IsMale = memberCampaignEditViewModel.Pet.IsMale;
                        pet.LastSeenDate = memberCampaignEditViewModel.Pet.LastSeenDate;
                        pet.LastSeenLocation = memberCampaignEditViewModel.Pet.LastSeenLocation;
                        pet.Microchipped = memberCampaignEditViewModel.Pet.Microchipped;
                        pet.Name = memberCampaignEditViewModel.Pet.Name;
                        pet.Strain = memberCampaignEditViewModel.Pet.Strain;
                        pet.Weight = memberCampaignEditViewModel.Pet.Weight;
                        pet.PetTypeId = _petTypeId;
                        context.SaveChanges();
                        //_petBLL.Update(advertimentViewModel.Pet);
                    }
                }
                else
                {
                    Pet newPet = new Pet();
                    newPet.Age = memberCampaignEditViewModel.Pet.Age;
                    newPet.Color = memberCampaignEditViewModel.Pet.Color;
                    newPet.Height = memberCampaignEditViewModel.Pet.Height;
                    newPet.IsFounded = memberCampaignEditViewModel.Pet.IsFounded;
                    newPet.IsMale = memberCampaignEditViewModel.Pet.IsMale;
                    newPet.LastSeenDate = memberCampaignEditViewModel.Pet.LastSeenDate;
                    newPet.LastSeenLocation = memberCampaignEditViewModel.Pet.LastSeenLocation;
                    newPet.Microchipped = memberCampaignEditViewModel.Pet.Microchipped;
                    newPet.Name = memberCampaignEditViewModel.Pet.Name;
                    newPet.Strain = memberCampaignEditViewModel.Pet.Strain;
                    newPet.Weight = memberCampaignEditViewModel.Pet.Weight;
                    newPet.PetTypeId = _petTypeId;
                    newPet.CreatedOn = DateTime.Now;
                    context.Pets.Add(newPet);
                    context.SaveChanges();
                    petId = context.Pets.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                    memberCampaignEditViewModel.Pet.Id = petId;
                }

                if (memberCampaignEditViewModel.HelpCampaignDetail.Id != default) //edit
                {
                    //var helpCampaignDetail = _helpCampaignDetailBLL.GetList().FirstOrDefault(x => x.Id == memberCampaignEditViewModel.HelpCampaignDetail.Id);
                    var helpCampaignDetail = context.HelpCampaignDetails.Where(x => x.Id == memberCampaignEditViewModel.HelpCampaignDetail.Id).FirstOrDefault();
                    if (helpCampaignDetail != null)
                    {
                        helpCampaignDetail.BankAccount = memberCampaignEditViewModel.HelpCampaignDetail.BankAccount;
                        helpCampaignDetail.CollectedAmount = memberCampaignEditViewModel.HelpCampaignDetail.CollectedAmount;
                        helpCampaignDetail.DonationAmount = memberCampaignEditViewModel.HelpCampaignDetail.DonationAmount;
                        helpCampaignDetail.IsVerifiedByAdmin = memberCampaignEditViewModel.HelpCampaignDetail.IsVerifiedByAdmin;
      
                        context.SaveChanges();
                        //_helpCampaignDetailBLL.Update(memberCampaignEditViewModel.HelpCampaignDetail);
                    }
                }
                else
                {
                    HelpCampaignDetail newHelpCampaignDetail = new HelpCampaignDetail();
                    memberCampaignEditViewModel.HelpCampaignDetail.CreatedOn = DateTime.Now;
                    context.HelpCampaignDetails.Add(memberCampaignEditViewModel.HelpCampaignDetail);
                    context.SaveChanges();
                    memberCampaignEditViewModel.HelpCampaignDetail.Id = context.HelpCampaignDetails.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                }

                memberCampaignEditViewModel.Post.PetId = memberCampaignEditViewModel.Pet.Id;
                memberCampaignEditViewModel.Post.HelpCampaignDetailId = memberCampaignEditViewModel.HelpCampaignDetail.Id;

                if (memberCampaignEditViewModel.Post.Id != default) //edit
                {
                    //var post = _postBLL.GetList().FirstOrDefault(x => x.Id == memberCampaignEditViewModel.Post.Id);
                    var post = context.Posts.Where(x => x.Id == memberCampaignEditViewModel.Post.Id).FirstOrDefault();

                    if (post != null)
                    {
                        post.AddressDescription = memberCampaignEditViewModel.Post.AddressDescription;
                        post.City = memberCampaignEditViewModel.Post.City;
                        post.CompletedDate = memberCampaignEditViewModel.Post.CompletedDate;
                        post.Content = memberCampaignEditViewModel.Post.Content;
                        post.District = memberCampaignEditViewModel.Post.District;
                        post.IsFounded = memberCampaignEditViewModel.Post.IsFounded;
                        post.Neighbourhood = memberCampaignEditViewModel.Post.Neighbourhood;
                        post.Note = memberCampaignEditViewModel.Post.Note;
                        post.Street = memberCampaignEditViewModel.Post.Street;
                        post.Title = memberCampaignEditViewModel.Post.Title;
                        context.SaveChanges();
                        //_postBLL.Update(memberCampaignEditViewModel.Post);
                    }
                }
                else
                {
                    memberCampaignEditViewModel.Post.CreatedOn = DateTime.Now;
                    memberCampaignEditViewModel.Post.IsApproved = true;
                    context.Posts.Add(memberCampaignEditViewModel.Post);
                    context.SaveChanges();
                    memberCampaignEditViewModel.Post.Id = context.Posts.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                    //_postBLL.Insert(memberCampaignEditViewModel.Post);
                }

                if (memberCampaignEditViewModel.ImageFile != null)
                {
                    ////Image Upload
                    //var global = HostingEnvironment.ApplicationPhysicalPath;
                    //string FileName = Path.GetFileNameWithoutExtension(memberCampaignEditViewModel.ImageFile.FileName);
                    //string FileExtension = Path.GetExtension(memberCampaignEditViewModel.ImageFile.FileName);
                    //FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                    //memberCampaignEditViewModel.Image = new Image { Path = Path.Combine("images", FileName) };
                    //memberCampaignEditViewModel.ImageFile.SaveAs(Path.Combine(global, memberCampaignEditViewModel.Image.Path));

                    //var postModelId = memberCampaignEditViewModel.Post.Id;
                    //memberCampaignEditViewModel.Image.ImagePostMappings = new List<ImagePostMapping>() { new ImagePostMapping { PostId = postModelId } };

                    //_imageBLL.Insert(memberCampaignEditViewModel.Image);
                    //Image Upload
                    var global = HostingEnvironment.ApplicationPhysicalPath;
                    string FileName = Path.GetFileNameWithoutExtension(memberCampaignEditViewModel.ImageFile.FileName);
                    string FileExtension = Path.GetExtension(memberCampaignEditViewModel.ImageFile.FileName);
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                    memberCampaignEditViewModel.Image = new Image { Path = Path.Combine("images", FileName) };
                    memberCampaignEditViewModel.ImageFile.SaveAs(Path.Combine(global, memberCampaignEditViewModel.Image.Path));

                    var postModelId = memberCampaignEditViewModel.Post.Id;
                    if (context.ImagePostMappings.Any(x => x.PostId == postModelId))
                    {
                        ImagePostMapping mapping1 = context.ImagePostMappings.Where(x => x.PostId == postModelId).FirstOrDefault();
                        Image img = context.Images.Where(x => x.Id == mapping1.ImageId).FirstOrDefault();
                        img.Path = FileName;
                        context.SaveChanges();
                    }
                    else
                    {
                        memberCampaignEditViewModel.Image.ImagePostMappings = new List<ImagePostMapping>() { new ImagePostMapping { CreatedOn = DateTime.Now, PostId = postModelId } };
                        memberCampaignEditViewModel.Image.Path = FileName;
                        memberCampaignEditViewModel.Image.CreatedOn = DateTime.Now;
                        //Image newImage = new Image();
                        //newImage.Path = FileName;
                        //newImage.CreatedOn = DateTime.Now;
                        context.Images.Add(memberCampaignEditViewModel.Image);
                        context.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var context = GetDatabaseContext();
            if (id != default)
            {
                var postModel = context.Posts.Where(x => x.Id == id).FirstOrDefault();
                if (postModel != null && Session["ID"] != null)
                {
                    postModel.IsDeleted = true;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("MyAdvertisements");
        }

        public ActionResult DeleteCampaign(int id)
        {
            var context = GetDatabaseContext();
            if (id != default)
            {
                var postModel = context.Posts.Where(x => x.Id == id).FirstOrDefault();
                if (postModel != null && Session["Id"] != null)
                {
                    postModel.IsDeleted = true;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult CompleteCampaign(int id)
        {
            var context = GetDatabaseContext();
            if (id != default)
            {
                var postModel = context.Posts.Where(x => x.Id == id).FirstOrDefault();
                if (postModel != null && Session["Id"] != null)
                {
                    postModel.IsFounded = true;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("FinishedCampaigns");
        }

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


