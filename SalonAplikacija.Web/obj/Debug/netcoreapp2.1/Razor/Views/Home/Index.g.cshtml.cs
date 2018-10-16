#pragma checksum "C:\Users\Hara\source\repos\SalonAplikacija\SalonAplikacija.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7545f8e13a2cc64c3f81205f31da5a4f0cb3e2be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Hara\source\repos\SalonAplikacija\SalonAplikacija.Web\Views\_ViewImports.cshtml"
using SalonAplikacija.Web;

#line default
#line hidden
#line 2 "C:\Users\Hara\source\repos\SalonAplikacija\SalonAplikacija.Web\Views\_ViewImports.cshtml"
using SalonAplikacija.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7545f8e13a2cc64c3f81205f31da5a4f0cb3e2be", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab8b39cf823407af27f7009fa17f75b3fca107ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../Account/Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Hara\source\repos\SalonAplikacija\SalonAplikacija.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 26091, true);
            WriteLiteral(@"
<!-- Header Section Start -->
<header id=""hero-area"" data-stellar-background-ratio=""0.5"">
    <!-- Navbar Start -->
    <nav class=""navbar navbar-expand-lg fixed-top scrolling-navbar indigo"">
        <div class=""container"">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class=""navbar-header"">
                <a href=""index.html"" class=""navbar-brand""><img class=""img-fulid"" src=""img/logo.png"" alt=""""></a>
                <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#main-navbar"" aria-controls=""main-navbar"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                    <i class=""lnr lnr-menu""></i>
                </button>
            </div>
            <div class=""collapse navbar-collapse"" id=""main-navbar"">
                <ul class=""navbar-nav mr-auto w-100 justify-content-end"">
                    <li class=""nav-item"">
                        <a class=""nav-link page-scroll"" href=""#hero-area"">Home</a>
");
            WriteLiteral(@"                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link page-scroll"" href=""#services"">About</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link page-scroll"" href=""#contactBlock"">Sign up</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link page-scroll"" href=""/Account/Login"">Sign in</a>
                    </li>
                </ul>
            </div>
        </div>

        <!-- Mobile Menu Start -->
        <ul class=""mobile-menu"">
            <li>
                <a class=""page-scroll"" href=""#hero-area"">Home</a>
            </li>
            <li>
                <a class=""page-scroll"" href=""#services"">Services</a>
            </li>
            <li>
                <a class=""page-scroll"" href=""#features"">Features</a>
            </li>
            <li>
                <a class=""page-scroll"" href=""#portfolio");
            WriteLiteral(@"s"">Works</a>
            </li>
            <li>
                <a class=""page-scroll"" href=""#pricing"">Pricing</a>
            </li>
            <li>
                <a class=""page-scroll"" href=""#team"">Team</a>
            </li>
            <li>
                <a class=""page-scroll"" href=""#blog"">Blog</a>
            </li>
            <li>
                <a class=""page-scroll"" href=""#contact"">Contact</a>
            </li>
        </ul>
        <!-- Mobile Menu End -->

    </nav>
    <!-- Navbar End -->
    <div class=""container"">
        <div class=""row justify-content-md-center"">
            <div class=""col-md-10"">
                <div class=""contents text-center"">
                    <h1 class=""wow fadeInDown"" data-wow-duration=""1000ms"" data-wow-delay=""0.3s"">Hair saloon manager</h1>
                    <p class=""lead  wow fadeIn"" data-wow-duration=""1000ms"" data-wow-delay=""400ms"">Managing your business has never been easier</p>
                </div>
            </div>
        </");
            WriteLiteral(@"div>
    </div>
</header>
<!-- Header Section End -->
<!-- Services Section Start -->
<section id=""services"" class=""section"">
    <div class=""container"">
        <div class=""section-header"">
            <h2 class=""section-title wow fadeIn"" data-wow-duration=""1000ms"" data-wow-delay=""0.3s"">About Us</h2>
            <hr class=""lines wow zoomIn"" data-wow-delay=""0.3s"">
            <p class=""section-subtitle wow fadeIn"" data-wow-duration=""1000ms"" data-wow-delay=""0.3s"">We allow you to sign up as a saloon owner and manager your business the way you want. <br></p>
        </div>
        <div class=""row"">
            <div class=""col-md-4 col-sm-6"">
                <div class=""item-boxes wow fadeInDown"" data-wow-delay=""0.2s"">
                    <div class=""icon"">
                        <i class=""lnr lnr-pencil""></i>
                    </div>
                    <h4>Customers info</h4>
                    <p>Manage number of active customers and orders</p>
                </div>
            </div>");
            WriteLiteral(@"
            <div class=""col-md-4 col-sm-6"">
                <div class=""item-boxes wow fadeInDown"" data-wow-delay=""0.8s"">
                    <div class=""icon"">
                        <i class=""lnr lnr-code""></i>
                    </div>
                    <h4>Appointments</h4>
                    <p>Information about latest appointments</p>
                </div>
            </div>
            <div class=""col-md-4 col-sm-6"">
                <div class=""item-boxes wow fadeInDown"" data-wow-delay=""1.2s"">
                    <div class=""icon"">
                        <i class=""lnr lnr-mustache""></i>
                    </div>
                    <h4>Finance</h4>
                    <p>Manage your finances and incomes</p>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Services Section End -->
<!-- Features Section Start -->
<!-- <section id=""features"" class=""section"" data-stellar-background-ratio=""0.2"">
   <div class=""container"">
     <div class=");
            WriteLiteral(@"""section-header"">
       <h2 class=""section-title"">Some Features</h2>
       <hr class=""lines"">
       <p class=""section-subtitle"">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quaerat, dignissimos! <br> Lorem ipsum dolor sit amet, consectetur.</p>
     </div>
     <div class=""row"">
       <div class=""col-lg-8 col-md-12 col-xs-12"">
         <div class=""container"">
           <div class=""row"">
              <div class=""col-lg-6 col-sm-6 col-xs-12 box-item"">
                 <span class=""icon"">
                   <i class=""lnr lnr-rocket""></i>
                 </span>
                 <div class=""text"">
                   <h4>Bootstrap 4 Based</h4>
                   <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                 </div>
               </div>
               <div class=""col-lg-6 col-sm-6 col-xs-12 box-item"">
                 <span class=""icon"">
                   <i class=""lnr lnr-laptop-phone""></i>
                 </span>
    ");
            WriteLiteral(@"             <div class=""text"">
                   <h4>Fully Responsive</h4>
                   <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                 </div>
               </div>
               <div class=""col-lg-6 col-sm-6 col-xs-12 box-item"">
                 <span class=""icon"">
                   <i class=""lnr lnr-layers""></i>
                 </span>
                 <div class=""text"">
                   <h4>Parallax Background</h4>
                   <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry</p>
                 </div>
               </div>
               <div class=""col-lg-6 col-sm-6 col-xs-12 box-item"">
                 <span class=""icon"">
                   <i class=""lnr lnr-cog""></i>
                 </span>
                 <div class=""text"">
                   <h4>Easy to Customize</h4>
                   <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry</p>
              ");
            WriteLiteral(@"   </div>
               </div>
           </div>
         </div>
       </div>
       <div class=""col-lg-4 col-xs-12"">
         <div class=""show-box"">
           <img class=""img-fulid"" src=""img/features/feature.png"" alt="""">
         </div>
       </div>
     </div>
   </div>
 </section>
 <!-- Features Section End -->
<!-- Portfolio Section -->
<!--<section id=""portfolios"" class=""section"">
  <!-- Container Starts -->
<!--  <div class=""container"">
    <div class=""section-header"">
      <h2 class=""section-title"">Our Portfolio</h2>
      <hr class=""lines"">
      <p class=""section-subtitle"">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quaerat, dignissimos! <br> Lorem ipsum dolor sit amet, consectetur.</p>
    </div>
    <div class=""row"">
      <div class=""col-md-12"">
        <!-- Portfolio Controller/Buttons -->
<!--     <div class=""controls text-center"">
       <a class=""filter active btn btn-common"" data-filter=""all"">
         All
       </a>
       <a class=""filter bt");
            WriteLiteral(@"n btn-common"" data-filter="".design"">
         Design
       </a>
       <a class=""filter btn btn-common"" data-filter="".development"">
         Development
       </a>
       <a class=""filter btn btn-common"" data-filter="".print"">
         Print
       </a>
     </div>
     <!-- Portfolio Controller/Buttons Ends-->
<!--     </div>

<!--     <!-- Portfolio Recent Projects -->
<!--  <div id=""portfolio"" class=""row"">
      <div class=""col-sm-6 col-md-4 col-lg-4 col-xl-4 mix development print"">
        <div class=""portfolio-item"">
          <div class=""shot-item"">
            <img src=""img/portfolio/img1.jpg"" alt="""" />
            <a class=""overlay lightbox"" href=""img/portfolio/img1.jpg"">
              <i class=""lnr lnr-eye item-icon""></i>
            </a>
          </div>
        </div>
      </div>
      <div class=""col-sm-6 col-md-4 col-lg-4 col-xl-4 mix design print"">
        <div class=""portfolio-item"">
          <div class=""shot-item"">
            <img src=""img/portfolio/img2.jpg"" al");
            WriteLiteral(@"t="""" />
            <a class=""overlay lightbox"" href=""img/portfolio/img2.jpg"">
              <i class=""lnr lnr-eye item-icon""></i>
            </a>
          </div>
        </div>
      </div>
      <div class=""col-sm-6 col-md-4 col-lg-4 col-xl-4 mix development"">
        <div class=""portfolio-item"">
          <div class=""shot-item"">
            <img src=""img/portfolio/img3.jpg"" alt="""" />
            <a class=""overlay lightbox"" href=""img/portfolio/img3.jpg"">
              <i class=""lnr lnr-eye item-icon""></i>
            </a>
          </div>
        </div>
      </div>
      <div class=""col-sm-6 col-md-4 col-lg-4 col-xl-4 mix development design"">
        <div class=""portfolio-item"">
          <div class=""shot-item"">
            <img src=""img/portfolio/img4.jpg"" alt="""" />
            <a class=""overlay lightbox"" href=""img/portfolio/img4.jpg"">
              <i class=""lnr lnr-eye item-icon""></i>
            </a>
          </div>
        </div>
      </div>
      <div class=""col-sm-6 co");
            WriteLiteral(@"l-md-4 col-lg-4 col-xl-4 mix development"">
        <div class=""portfolio-item"">
          <div class=""shot-item"">
            <img src=""img/portfolio/img5.jpg"" alt="""" />
            <a class=""overlay lightbox"" href=""img/portfolio/img5.jpg"">
              <i class=""lnr lnr-eye item-icon""></i>
            </a>
          </div>
        </div>
      </div>
      <div class=""col-sm-6 col-md-4 col-lg-4 col-xl-4 mix print design"">
        <div class=""portfolio-item"">
          <div class=""shot-item"">
            <img src=""img/portfolio/img6.jpg"" alt="""" />
            <a class=""overlay lightbox"" href=""img/portfolio/img6.jpg"">
              <i class=""lnr lnr-eye item-icon""></i>
            </a>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
<!-- Container Ends -->
    </section>
<!-- Portfolio Section Ends -->
<!-- Start Video promo Section -->
<!-- <section class=""video-promo section"">
   <div class=""container"">
     <div class=""row justify-content-center"">
     ");
            WriteLiteral(@"  <div class=""col-lg-8"">
           <div class=""video-promo-content text-center"">
             <h2 class=""wow zoomIn"" data-wow-duration=""1000ms"" data-wow-delay=""100ms"">Watch Our Intro video</h2>
             <p class=""wow zoomIn"" data-wow-duration=""1000ms"" data-wow-delay=""100ms"">Aliquam vestibulum cursus felis. In iaculis iaculis sapien ac condimentum. Vestibulum congue posuere lacus, id tincidunt nisi porta sit amet. Suspendisse et sapien varius, pellentesque dui non, semper orci.</p>
             <a href=""https://www.youtube.com/watch?v=IXoMDwh4Cq8"" class=""video-popup wow fadeInUp"" data-wow-duration=""1000ms"" data-wow-delay=""0.3s""><i class=""lnr lnr-film-play""></i></a>
           </div>
       </div>
     </div>
   </div>
 </section>
 <!-- End Video Promo Section -->
<!-- Start Pricing Table Section -->
<!--  <div id=""pricing"" class=""section pricing-section"">
    <div class=""container"">
      <div class=""section-header"">
        <h2 class=""section-title"">Pricing Table</h2>
        <hr class=""l");
            WriteLiteral(@"ines"">
        <p class=""section-subtitle"">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quaerat, dignissimos! <br> Lorem ipsum dolor sit amet, consectetur.</p>
      </div>

      <div class=""row pricing-tables"">
        <div class=""col-md-4 col-sm-6 col-xs-12"">
          <div class=""pricing-table"">
            <div class=""pricing-details"">
              <h2>Free</h2>
              <span>$00</span>
              <ul>
                <li>Consectetur adipiscing</li>
                <li>Nunc luctus nulla et tellus</li>
                <li>Suspendisse quis metus</li>
                <li>Vestibul varius fermentum erat</li>
              </ul>
            </div>
            <div class=""plan-button"">
              <a href=""#"" class=""btn btn-common"">Get Plan</a>
            </div>
          </div>
        </div>

        <div class=""col-md-4 col-sm-6 col-xs-12"">
          <div class=""pricing-table"">
            <div class=""pricing-details"">
              <h2>Popular</h2>
      ");
            WriteLiteral(@"        <span>$3.99</span>
              <ul>
                <li>Consectetur adipiscing</li>
                <li>Nunc luctus nulla et tellus</li>
                <li>Suspendisse quis metus</li>
                <li>Vestibul varius fermentum erat</li>
              </ul>
            </div>
            <div class=""plan-button"">
              <a href=""#"" class=""btn btn-common"">Buy Now</a>
            </div>
          </div>
        </div>

        <div class=""col-md-4 col-sm-6 col-xs-12"">
          <div class=""pricing-table"">
            <div class=""pricing-details"">
              <h2>Premium</h2>
              <span>$9.50</span>
              <ul>
                <li>Consectetur adipiscing</li>
                <li>Nunc luctus nulla et tellus</li>
                <li>Suspendisse quis metus</li>
                <li>Vestibul varius fermentum erat</li>
              </ul>
            </div>
            <div class=""plan-button"">
              <a href=""#"" class=""btn btn-common"">Buy Now</a>");
            WriteLiteral(@"
            </div>
          </div>
        </div>

      </div>
    </div>
  </div>
  <!-- End Pricing Table Section -->
<!-- Counter Section Start -->
<div class=""counters section"" data-stellar-background-ratio=""0.5"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-sm-6 col-md-3 col-lg-3"">
                <div class=""facts-item"">
                    <div class=""icon"">
                        <i class=""lnr lnr-clock""></i>
                    </div>
                    <div class=""fact-count"">
                        <h3><span class=""counter"">1589</span></h3>
                        <h4>Working Hours</h4>
                    </div>
                </div>
            </div>
            <div class=""col-sm-6 col-md-3 col-lg-3"">
                <div class=""facts-item"">
                    <div class=""icon"">
                        <i class=""lnr lnr-briefcase""></i>
                    </div>
                    <div class=""fact-count"">
               ");
            WriteLiteral(@"         <h3><span class=""counter"">699</span></h3>
                        <h4>Completed Projects</h4>
                    </div>
                </div>
            </div>
            <div class=""col-sm-6 col-md-3 col-lg-3"">
                <div class=""facts-item"">
                    <div class=""icon"">
                        <i class=""lnr lnr-user""></i>
                    </div>
                    <div class=""fact-count"">
                        <h3><span class=""counter"">203</span></h3>
                        <h4>No. of Clients</h4>
                    </div>
                </div>
            </div>
            <div class=""col-sm-6 col-md-3 col-lg-3"">
                <div class=""facts-item"">
                    <div class=""icon"">
                        <i class=""lnr lnr-heart""></i>
                    </div>
                    <div class=""fact-count"">
                        <h3><span class=""counter"">1689</span></h3>
                        <h4>Peoples Love</h4>
               ");
            WriteLiteral(@"     </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Counter Section End -->
<!-- Team section Start -->
<!--  <section id=""team"" class=""section"">
  <div class=""container"">
    <div class=""section-header"">
      <h2 class=""section-title"">Our Team</h2>
      <hr class=""lines"">
      <p class=""section-subtitle"">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quaerat, dignissimos! <br> Lorem ipsum dolor sit amet, consectetur.</p>
    </div>
    <div class=""row"">
      <div class=""col-lg-3 col-md-6 col-xs-12"">
        <div class=""single-team"">
          <img src=""img/team/team1.jpg"" alt="""">
          <div class=""team-details"">
            <div class=""team-inner"">
              <h4 class=""team-title"">Jhon Doe</h4>
              <p>Chief Technical Officer</p>
              <ul class=""social-list"">
                <li class=""facebook""><a href=""#""><i class=""fa fa-facebook""></i></a></li>
                <li class=""twitter""><a href=""#""><i class=""");
            WriteLiteral(@"fa fa-twitter""></i></a></li>
                <li class=""google-plus""><a href=""#""><i class=""fa fa-google-plus""></i></a></li>
                <li class=""linkedin""><a href=""#""><i class=""fa fa-linkedin""></i></a></li>
              </ul>
            </div>
          </div>
        </div>
      </div>
      <div class=""col-lg-3 col-md-6 col-xs-12"">
        <div class=""single-team"">
          <img src=""img/team/team2.jpg"" alt="""">
          <div class=""team-details"">
            <div class=""team-inner"">
              <h4 class=""team-title"">Paul Kowalsy</h4>
              <p>CEO & Co-Founder</p>
              <ul class=""social-list"">
                <li class=""facebook""><a href=""#""><i class=""fa fa-facebook""></i></a></li>
                <li class=""twitter""><a href=""#""><i class=""fa fa-twitter""></i></a></li>
                <li class=""google-plus""><a href=""#""><i class=""fa fa-google-plus""></i></a></li>
                <li class=""linkedin""><a href=""#""><i class=""fa fa-linkedin""></i></a></li>
           ");
            WriteLiteral(@"   </ul>
            </div>
          </div>
        </div>
      </div>
      <div class=""col-lg-3 col-md-6 col-xs-12"">
        <div class=""single-team"">
          <img src=""img/team/team3.jpg"" alt="""">
          <div class=""team-details"">
            <div class=""team-inner"">
              <h4 class=""team-title"">Emilly Williams</h4>
              <p>Business Manager</p>
              <ul class=""social-list"">
                <li class=""facebook""><a href=""#""><i class=""fa fa-facebook""></i></a></li>
                <li class=""twitter""><a href=""#""><i class=""fa fa-twitter""></i></a></li>
                <li class=""google-plus""><a href=""#""><i class=""fa fa-google-plus""></i></a></li>
                <li class=""linkedin""><a href=""#""><i class=""fa fa-linkedin""></i></a></li>
              </ul>
            </div>
          </div>
        </div>
      </div>
      <div class=""col-lg-3 col-md-6 col-xs-12"">
        <div class=""single-team"">
          <img class=""img-fulid"" src=""img/team/team4.jpg"" alt=");
            WriteLiteral(@""""">
          <div class=""team-details"">
            <div class=""team-inner"">
              <h4 class=""team-title"">Patricia Green</h4>
              <p>Graphic Designer</p>
              <ul class=""social-list"">
                <li class=""facebook""><a href=""#""><i class=""fa fa-facebook""></i></a></li>
                <li class=""twitter""><a href=""#""><i class=""fa fa-twitter""></i></a></li>
                <li class=""google-plus""><a href=""#""><i class=""fa fa-google-plus""></i></a></li>
                <li class=""linkedin""><a href=""#""><i class=""fa fa-linkedin""></i></a></li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
<!-- Team section End -->
<!-- testimonial Section Start -->
<!--   <div id=""testimonial"" class=""section"" data-stellar-background-ratio=""0.1"">
   <div class=""container"">
     <div class=""row justify-content-md-center"">
       <div class=""col-md-12"">
         <div class=""touch-slider owl-carousel owl-theme"">
   ");
            WriteLiteral(@"        <div class=""testimonial-item"">
             <img src=""img/testimonial/customer1.jpg"" alt=""Client Testimonoal"" />
             <div class=""testimonial-text"">
               <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. send do <br> adipisicing ciusmod tempor incididunt ut labore et</p>
               <h3>Jone Deam</h3>
               <span>Fondor of Jalmori</span>
             </div>
           </div>
           <div class=""testimonial-item"">
             <img src=""img/testimonial/customer2.jpg"" alt=""Client Testimonoal"" />
             <div class=""testimonial-text"">
               <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. send do <br> adipisicing ciusmod tempor incididunt ut labore et</p>
               <h3>Oidila Matik</h3>
               <span>President Lexo Inc</span>
             </div>
           </div>
           <div class=""testimonial-item"">
             <img src=""img/testimonial/customer3.jpg"" alt=""Client Testimonoal"" />
             <div cla");
            WriteLiteral(@"ss=""testimonial-text"">
               <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. send do <br> adipisicing ciusmod tempor incididunt ut labore et</p>
               <h3>Alex Dattilo</h3>
               <span>CEO Optima Inc</span>
             </div>
           </div>
           <div class=""testimonial-item"">
             <img src=""img/testimonial/customer4.jpg"" alt=""Client Testimonoal"" />
             <div class=""testimonial-text"">
               <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. send do <br> adipisicing ciusmod tempor incididunt ut labore et</p>
               <h3>Paul Kowalsy</h3>
               <span>CEO & Founder</span>
             </div>
           </div>
         </div>
       </div>
     </div>
   </div>
 </div>
 <!-- testimonial Section Start -->
<!-- Blog Section -->
<!--   <section id=""blog"" class=""section"">
   <!-- Container Starts -->
<!--  <div class=""container"">
  <div class=""section-header"">
    <h2 class=""section-title"">Rece");
            WriteLiteral(@"nt Blog</h2>
    <hr class=""lines"">
    <p class=""section-subtitle"">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quaerat, dignissimos! <br> Lorem ipsum dolor sit amet, consectetur.</p>
  </div>
  <div class=""row"">
    <div class=""col-lg-4 col-md-4 col-sm-6 col-xs-12 blog-item"">
      <!-- Blog Item Starts -->
<!--    <div class=""blog-item-wrapper"">
    <div class=""blog-item-img"">
      <a href=""single-post.html"">
        <img src=""img/blog/img1.jpg"" alt="""">
      </a>
    </div>
    <div class=""blog-item-text"">
      <div class=""meta-tags"">
        <span class=""date""><i class=""lnr  lnr-clock""></i>2 Days Ago</span>
        <span class=""comments""><a href=""#""><i class=""lnr lnr-bubble""></i> 24 Comments</a></span>
      </div>
      <h3>
        <a href=""single-post.html"">How often should you tweet?</a>
      </h3>
      <p>
      Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua...
      </p>
      <a hr");
            WriteLiteral(@"ef=""single-post.html"" class=""btn-rm"">Read More <i class=""lnr lnr-arrow-right""></i></a>
    </div>
  </div>
  <!-- Blog Item Wrapper Ends-->
<!--    </div>

  <div class=""col-lg-4 col-md-4 col-sm-6 col-xs-12 blog-item"">
    <!-- Blog Item Starts -->
<!--     <div class=""blog-item-wrapper"">
     <div class=""blog-item-img"">
       <a href=""single-post.html"">
         <img src=""img/blog/img2.jpg"" alt="""">
       </a>
     </div>
     <div class=""blog-item-text"">
       <div class=""meta-tags"">
         <span class=""date""><i class=""lnr  lnr-clock""></i>2 Days Ago</span>
         <span class=""comments""><a href=""#""><i class=""lnr lnr-bubble""></i> 24 Comments</a></span>
       </div>
       <h3>
         <a href=""single-post.html"">Content is still king</a>
       </h3>
       <p>
       Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua...
       </p>
       <a href=""single-post.html"" class=""btn-rm"">Read More <i class=""lnr l");
            WriteLiteral(@"nr-arrow-right""></i></a>
     </div>
   </div>
   <!-- Blog Item Wrapper Ends-->
<!--       </div>

     <div class=""col-lg-4 col-md-4 col-sm-6 col-xs-12 blog-item"">
       <!-- Blog Item Starts -->
<!--     <div class=""blog-item-wrapper"">
     <div class=""blog-item-img"">
       <a href=""single-post.html"">
         <img src=""img/blog/img3.jpg"" alt="""">
       </a>
     </div>
     <div class=""blog-item-text"">
       <div class=""meta-tags"">
         <span class=""date""><i class=""lnr  lnr-clock""></i>2 Days Ago</span>
         <span class=""comments""><a href=""#""><i class=""lnr lnr-bubble""></i> 24 Comments</a></span>
       </div>
       <h3>
         <a href=""single-post.html"">Social media at work</a>
       </h3>
       <p>
        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua...
       </p>
       <a href=""single-post.html"" class=""btn-rm"">Read More <i class=""lnr lnr-arrow-right""></i></a>
     </div>
   </div>
");
            WriteLiteral(@"   <!-- Blog Item Wrapper Ends-->
<!--     </div>
    </div>
  </div>
</section>
<!-- blog Section End -->
<!-- Contact Section Start -->
<section id=""contact"" class=""section"" data-stellar-background-ratio=""-0.2"">
    <div class=""contact-form"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-2""></div>
                <div class=""col-lg-8 offset-3 col-sm-6 col-xs-12"">
                    <h3>Sign up</h3>
                     ");
            EndContext();
            BeginContext(26136, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a473ec1c87f749abbd8d7a1667d47893", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(26174, 1260, true);
            WriteLiteral(@"
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Contact Section End -->
<!-- Footer Section Start -->
<footer>
    <div class=""container"">
        <div class=""row"">
            <!-- Footer Links -->
            <div class=""col-lg-6 col-sm-6 col-xs-12"">
                <ul class=""footer-links"">
                    <li>
                        <a href=""#"">Homepage</a>
                    </li>
                    <li>
                        <a href=""#"">Services</a>
                    </li>
                    <li>
                        <a href=""#"">About Us</a>
                    </li>
                    <li>
                        <a href=""#"">Contact</a>
                    </li>
                </ul>
            </div>
            <div class=""col-lg-6 col-sm-6 col-xs-12"">
                <div class=""copyright"">
                    <p>All copyrights reserved &copy; 2018 - Designed & Developed by <a rel=""nofollow"" href=""https://uideck.com""");
            WriteLiteral(">UIdeck</a></p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</footer>\r\n<!-- Footer Section End -->\r\n<!-- Go To Top Link -->\r\n<a href=\"#\" class=\"back-to-top\">\r\n    <i class=\"lnr lnr-arrow-up\"></i>\r\n</a>\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
