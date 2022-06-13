
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
using SCRP.DAL.EF;


namespace SCRP.Web.Controllers
{
    public class MemberController : Controller
    {
        public DatabaseContext GetDatabaseContext()
        {
            DatabaseContext context = new DatabaseContext();
            context.Configuration.LazyLoadingEnabled = false;
            return context;
        }

        //DatabaseContext context = new DatabaseContext();

        public ActionResult Index()
        {
            // Kullanıcı personal info larını gördüğü yer
            return View();
        }

        public ActionResult MemberInformation()
        {
            var context = GetDatabaseContext();
            int userId = Convert.ToInt32(Session["ID"]);
            Member member = context.Members.Where(x => x.Id == userId).FirstOrDefault();
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Member = member;

            //int memberId = AuthorizationCheckMember();
            //if (memberId == default)
            //{
            //    return RedirectToAction("Logout", "User");
            //}

            //UserEditViewModel userEditViewModel = new UserEditViewModel();

            //userEditViewModel.Member = _memberBLL.GetById(memberId);

            //return View(userEditViewModel);
            return View(userEditViewModel) ;
        }

        public ActionResult MemberEdit()
        {
            var context = GetDatabaseContext();
            if (Session["ID"].ToString() == "null")
            {
                return RedirectToAction("Logout", "User");
            }
            int memberId = Convert.ToInt32(Session["ID"]);
            Member member = context.Members.Where(x => x.Id == memberId).FirstOrDefault();
            
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Member = member;

            return View(userEditViewModel);
        }

        [HttpPost]
        public ActionResult MemberEdit(UserEditViewModel userEditViewModel)
        {
            var context = GetDatabaseContext();
            if (userEditViewModel.Member != null)
            {
                if (Session["Id"] != null)
                {
                    var userId = int.Parse(Session["Id"].ToString());
                    var member = context.Members.Where(x => x.Id == userId).FirstOrDefault();
                    if (member != null)
                    {
                        member.City = userEditViewModel.Member.City;
                        member.District = userEditViewModel.Member.District;
                        member.FirstName = userEditViewModel.Member.FirstName;
                        member.LastName = userEditViewModel.Member.LastName;
                        member.Phone = userEditViewModel.Member.Phone;
                        member.SecondPhone = userEditViewModel.Member.SecondPhone;
                        member.IBAN = userEditViewModel.Member.IBAN;
                        member.Email = userEditViewModel.Member.Email;
                        member.Birthdate = userEditViewModel.Member.Birthdate;
                        context.SaveChanges();
                        Session["FullName"] = $"{userEditViewModel.Member.FirstName} {userEditViewModel.Member.LastName}";
                    }
                    //else
                    //{
                    //    _memberBLL.Insert(userEditViewModel.Member);
                    //}
                    return RedirectToAction("MemberInformation");
                }
                else
                {
                    return RedirectToAction("Logout", "User");
                }
            }

            return View();
        }

        public ActionResult MyAdvertisements()
        {
            var context = GetDatabaseContext();
            if (Session["ID"].ToString() == "null")
            {
                return RedirectToAction("Logout", "User");
            }
            int memberId = Convert.ToInt32(Session["ID"]);
           
            List<Post> posts = context.Posts.Include("ImagePostMappings").Include("ImagePostMappings.Image")
                .Where(x => x.PostTypeId == 1 && !x.IsDeleted && x.MemberId == memberId).ToList();

    

            PostListViewModel postListViewModel = new PostListViewModel();
            postListViewModel.Posts = posts;

            return View(postListViewModel);
   
        }

        public ActionResult AdvertisementDetail(int? id)
        {
            var context = GetDatabaseContext();
            if (Session["ID"].ToString() == "null")
            {
                return RedirectToAction("Logout", "User");
            }
            int memberId = Convert.ToInt32(Session["ID"]);
            if (id.HasValue && id.Value != default) //Detail
            {
                Post post = context.Posts.Include("Member").Include("Pet").Include("ImagePostMappings").Include("ImagePostMappings.Image")
                    .Where(x => x.Id == id).FirstOrDefault();
                AdvertisementPetViewModel advertisementPetViewModel = new AdvertisementPetViewModel();
                advertisementPetViewModel.Post = post;
                //var pets = context.Pets.ToList();
                //var ımagePostMappingList = _imagePostMappingBLL.GetList();
                //var ımageList = _imageBLL.GetList();

                //var member = context.Members.Where(x => x.Id == memberId).FirstOrDefault();

                //AdvertisementPetViewModel advertisementPetViewModel = new AdvertisementPetViewModel();
                //advertisementPetViewModel.Post = post;

                //var lastImage = ımagePostMappingList.LastOrDefault(x => x.PostId == advertisementPetViewModel.Post.Id);
                //var selectedPet = pets.FirstOrDefault(x => x.Id == advertisementPetViewModel.Post.PetId);

                //if (selectedPet != null)
                //{
                //    advertisementPetViewModel.Post.Pet = selectedPet;
                //}

                //if (member != null)
                //{
                //    advertisementPetViewModel.Post.Member = member;
                //}

                //if (lastImage != null)
                //{
                //    var imageModel = ımageList.FirstOrDefault(x => x.Id == lastImage.ImageId);
                //    if (imageModel != null)
                //    {
                //        imageModel.Path = Path.Combine("/", imageModel.Path);
                //        advertisementPetViewModel.Post.ImagePostMappings = new List<ImagePostMapping>() { new ImagePostMapping() { Image = imageModel } };
                //    }
                //}
                //else
                //{
                //    advertisementPetViewModel.Post.ImagePostMappings = new List<ImagePostMapping>() { new ImagePostMapping() { Image = new Image { Path = Path.Combine("/", "images", "toy-poodle.jpg") } } };
                //}
                return View(advertisementPetViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult EditAdvertisement(int? id)
        {
            //if ( TempData["NEWAD"] != null)
            //{

            //}
            var context = GetDatabaseContext();
            if (Session["ID"].ToString() == "null")
            {
                return RedirectToAction("Logout", "User");
            }
            int memberId = Convert.ToInt32(Session["ID"]);
            MemberAdvertisementEditViewModel memberAdvertimentEditViewModel = new MemberAdvertisementEditViewModel();
            if (id.HasValue && id.Value != default) //Edit
            {
                var post = context.Posts.Where( x=> x.Id == id ).FirstOrDefault();
                memberAdvertimentEditViewModel.Post = post;

                int petId = post.PetId;

                //var pet = _petBLL.GetById(petId);
                Pet pet = context.Pets.Where(x => x.Id == petId).FirstOrDefault();
                memberAdvertimentEditViewModel.Pet = pet;
                if (pet.PetTypeId == 1)
                    memberAdvertimentEditViewModel.PetType = "Dog";
                else
                    memberAdvertimentEditViewModel.PetType = "Cat";
                //var imagePostMapping = _imagePostMappingBLL.GetList().LastOrDefault(x => x.PostId == post.Id);
                var imagePostMapping = context.ImagePostMappings.Include("Image").Where(x => x.PostId == post.Id).FirstOrDefault();
                if (imagePostMapping != null)
                {
                    memberAdvertimentEditViewModel.Image = imagePostMapping.Image;
                    //memberAdvertimentEditViewModel.Image.Path = Path.Combine("/", memberAdvertimentEditViewModel.Image.Path);
                }
                else
                {
                    memberAdvertimentEditViewModel.Image = new Image() { Path = Path.Combine("/", "images", "toy-poodle.jpg") };
                }
                memberAdvertimentEditViewModel.Post.MissedDate = DateTime.Now;
                return View(memberAdvertimentEditViewModel);
            }
            else
            {
                memberAdvertimentEditViewModel.Pet = new Pet();
                memberAdvertimentEditViewModel.Post = new Post();
                memberAdvertimentEditViewModel.Image = new Image();
                memberAdvertimentEditViewModel.Post.MissedDate = DateTime.Now;
                return View(memberAdvertimentEditViewModel);
            }
        }

        [HttpPost]
        public ActionResult EditAdvertisement(MemberAdvertisementEditViewModel advertimentViewModel)
        {
            var context = GetDatabaseContext();
            if (Session["ID"].ToString() == "null")
            {
                return RedirectToAction("Logout", "User");
            }
            int _petTypeId = 0;
            if (advertimentViewModel.PetType == "Cat")
            {
                _petTypeId = 2;
            }
            else
            {
                _petTypeId = 1;
            }
            //int petTypeId = SCRP.Foundation.Enums.PetType.Cat
            int memberId = Convert.ToInt32(Session["ID"]);
            if (advertimentViewModel.Pet != null && advertimentViewModel.Post != null)
            {
                int petId = advertimentViewModel.Pet.Id;
                advertimentViewModel.Post.PostTypeId = 1;
                advertimentViewModel.Post.MemberId = memberId;
                advertimentViewModel.Post.CompletedDate = DateTime.Now.AddDays(10);
                
                if (!CheckModelState())
                {
                    advertimentViewModel.Post.MissedDate = DateTime.Now;
                    advertimentViewModel.Image = new Image();
                    return View(advertimentViewModel);
                }

                if (advertimentViewModel.Pet.Id != default) //edit
                {
                    var pet = context.Pets.Where(x => x.Id == advertimentViewModel.Pet.Id).FirstOrDefault();

                    if (pet != null)
                    {
                        pet.Age = advertimentViewModel.Pet.Age;
                        pet.Color = advertimentViewModel.Pet.Color;
                        pet.Height = advertimentViewModel.Pet.Height;
                        pet.IsFounded = advertimentViewModel.Pet.IsFounded;
                        pet.IsMale = advertimentViewModel.Pet.IsMale;
                        pet.LastSeenDate = advertimentViewModel.Pet.LastSeenDate;
                        pet.LastSeenLocation = advertimentViewModel.Pet.LastSeenLocation;
                        pet.Microchipped = advertimentViewModel.Pet.Microchipped;
                        pet.Name = advertimentViewModel.Pet.Name;
                        pet.Strain = advertimentViewModel.Pet.Strain;
                        pet.Weight = advertimentViewModel.Pet.Weight;
                        pet.PetTypeId = _petTypeId;
                        context.SaveChanges();
                        //_petBLL.Update(advertimentViewModel.Pet);
                    }
                }
                else
                {
                    Pet newPet = new Pet();
                    newPet.Age = advertimentViewModel.Pet.Age;
                    newPet.Color = advertimentViewModel.Pet.Color;
                    newPet.Height = advertimentViewModel.Pet.Height;
                    newPet.IsFounded = advertimentViewModel.Pet.IsFounded;
                    newPet.IsMale = advertimentViewModel.Pet.IsMale;
                    newPet.LastSeenDate = advertimentViewModel.Pet.LastSeenDate;
                    newPet.LastSeenLocation = advertimentViewModel.Pet.LastSeenLocation;
                    newPet.Microchipped = advertimentViewModel.Pet.Microchipped;
                    newPet.Name = advertimentViewModel.Pet.Name;
                    newPet.Strain = advertimentViewModel.Pet.Strain;
                    newPet.Weight = advertimentViewModel.Pet.Weight;                    
                    newPet.PetTypeId = _petTypeId;
                    newPet.CreatedOn = DateTime.Now;
                    context.Pets.Add(newPet);
                    context.SaveChanges();
                    petId = context.Pets.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                    advertimentViewModel.Pet.Id = petId;
                    //_petBLL.Insert(advertimentViewModel.Pet);
                }

                
                advertimentViewModel.Post.PetId = advertimentViewModel.Pet.Id;


                if (advertimentViewModel.Post.Id != default) //edit
                {
                    //var post = _postBLL.GetList().FirstOrDefault(x => x.Id == advertimentViewModel.Post.Id);
                    var post = context.Posts.Where(x => x.Id == advertimentViewModel.Post.Id).FirstOrDefault();
                    if (post != null)
                    {
                        post.AddressDescription = advertimentViewModel.Post.AddressDescription;
                        post.City = advertimentViewModel.Post.City;
                        post.CompletedDate = advertimentViewModel.Post.CompletedDate;
                        post.Content = advertimentViewModel.Post.Content;
                        post.District = advertimentViewModel.Post.District;
                        post.IsFounded = advertimentViewModel.Post.IsFounded;
                        post.Neighbourhood = advertimentViewModel.Post.Neighbourhood;
                        post.Note = advertimentViewModel.Post.Note;
                        post.Street = advertimentViewModel.Post.Street;
                        post.Title = advertimentViewModel.Post.Title;
                        context.SaveChanges();
                        //_postBLL.Update(advertimentViewModel.Post);
                    }
                }
                else
                {
                    advertimentViewModel.Post.CreatedOn = DateTime.Now;
                    advertimentViewModel.Post.IsApproved = true;
                    context.Posts.Add(advertimentViewModel.Post);
                    context.SaveChanges();
                    advertimentViewModel.Post.Id = context.Posts.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                    //_postBLL.Insert(advertimentViewModel.Post);
                }

                if (advertimentViewModel.ImageFile != null)
                {
                    //Image Upload
                    var global = HostingEnvironment.ApplicationPhysicalPath;
                    string FileName = Path.GetFileNameWithoutExtension(advertimentViewModel.ImageFile.FileName);
                    string FileExtension = Path.GetExtension(advertimentViewModel.ImageFile.FileName);
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                    advertimentViewModel.Image = new Image { Path = Path.Combine("images", FileName) };
                    advertimentViewModel.ImageFile.SaveAs(Path.Combine(global, advertimentViewModel.Image.Path));

                    var postModelId = advertimentViewModel.Post.Id;
                    if ( context.ImagePostMappings.Any(x=> x.PostId == postModelId))
                    {
                        ImagePostMapping mapping1 = context.ImagePostMappings.Where(x => x.PostId == postModelId).FirstOrDefault();
                        Image img = context.Images.Where(x => x.Id == mapping1.ImageId).FirstOrDefault();
                        img.Path = FileName;
                        context.SaveChanges();
                    }
                    else
                    {
                        advertimentViewModel.Image.ImagePostMappings = new List<ImagePostMapping>() { new ImagePostMapping { CreatedOn = DateTime.Now, PostId = postModelId } };
                        advertimentViewModel.Image.Path = FileName;
                        advertimentViewModel.Image.CreatedOn = DateTime.Now;
                        //Image newImage = new Image();
                        //newImage.Path = FileName;
                        //newImage.CreatedOn = DateTime.Now;
                        context.Images.Add(advertimentViewModel.Image);
                        context.SaveChanges();
                    }

                    
                    //_imageBLL.Insert(advertimentViewModel.Image);
                }
            }


            return RedirectToAction("MyAdvertisements");
        }

        public ActionResult MyPetsFound()
        {
            var context = GetDatabaseContext();
            if (Session["ID"].ToString() == "null")
            {
                return RedirectToAction("Logout", "User");
            }
            int memberId = Convert.ToInt32(Session["ID"]);

            //var posts = _postBLL.GetList().Where(x => x.PostTypeId == Foundation.Enums.PostTypes.Missing && x.IsFounded == true && !x.IsDeleted && memberId == x.MemberId);

            List<Post> posts = context.Posts.Include("ImagePostMappings").Include("ImagePostMappings.Image")
                .Where(x => x.PostTypeId == 1 && x.IsFounded && !x.IsDeleted && x.MemberId == memberId).ToList();

            PostListViewModel postListViewModel = new PostListViewModel();
            postListViewModel.Posts = posts;
            //FillImagePosts(postListViewModel);
            return View(postListViewModel);
        }

        public ActionResult FoundAdvertisement(int id)
        {
            var context = GetDatabaseContext();
            if (Session["ID"].ToString() == "null")
            {
                return RedirectToAction("Logout", "User");
            }
            int memberId = Convert.ToInt32(Session["ID"]);

            var post = context.Posts.Where(x => x.Id == id).FirstOrDefault();

            if (post != null)
            {
                post.IsFounded = true;
                context.SaveChanges();
            }

            return RedirectToAction("MyPetsFound");
        }

        public ActionResult DeleteAdvertisement(int id)
        {
            var context = GetDatabaseContext();
            if (Session["ID"].ToString() == "null")
            {
                return RedirectToAction("Logout", "User");
            }
            int memberId = Convert.ToInt32(Session["ID"]);


            var post = context.Posts.Where(x => x.Id == id).FirstOrDefault();

            if (post != null)
            {
                post.IsDeleted = true;
                context.SaveChanges();
            }

            return RedirectToAction("MyAdvertisements");
        }

        public ActionResult PostNewAd()
        {
            TempData["NEWAD"] = "new";
            return RedirectToAction("EditAdvertisement");
        }

       

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