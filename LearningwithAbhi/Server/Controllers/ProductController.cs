
using Microsoft.AspNetCore.Mvc;

namespace LearningwithAbhi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //   public static List<ProductModel> pr = new List<ProductModel>()
                    //Simplify new expression (IDE0090)
        public static List<ProductModel> pr = new ()
        {
            new ProductModel
            {
                Id= 1, Name="Think & Grow Rich",Description= "Think and Grow Rich is the 1# inspirational and motivational classic for individuals who are interested in achieving their goals and succeeding in life. Drawing inspiration from the lives of Andrew Carnegie, Thomas Edison, Henry Ford, and other millionaires of his generation, Napoleon Hill reveals the life-changing secret to securing exceptional wealth and success.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/e/e9/Think_and_grow_rich_original_cover.jpg/160px-Think_and_grow_rich_original_cover.jpg", Price = 84.00
            },

            new ProductModel{

                    Id= 2, Name="The Power of Your Subconscious Mind",
                Description= "The Power of Your Subconscious Mind has inspired millions of readers to unlock the unseen forces and invisible power within them. Dr Murphy's mind-focusing techniques are based on a simple principle: If you believe in something without reservation and picture it in your mind, you can remove the subconscious obstacles that prevent you from achieving the results you want, and your belief can become a reality.",
                ImageUrl="https://d1b14unh5d6w7g.cloudfront.net/9380494203.01.S001.LXXXXXXX.jpg?Expires=1687758446&Signature=DAC5sOKHr3dgubzH~uXrwww0a2K-4viozHcYcw5MHEAJg0o57EIk9rebX4Dm8ih0GY7cLWrWODUJIscnQp-gt0pI9a4IGqm6Y5Q37eLb3K~95yt7loZutujxcQQU1wtVO-2JheWS-OqhGua7eOeKL7vRgU6b72lEqB72VZBbGE0_&Key-Pair-Id=APKAIUO27P366FGALUMQ",
                Price = 50.56
            },

            new ProductModel{

                Id= 3,  Name="The Healing Power of Love",
                Description= "BOOKS BY DR. JOSEPH MURPHY The Amazing Laws of Cosmic Mind Power The Cosmic Energizer: Miracle Power of the Universe The Cosmic Power Within You Great Bible Truths for Human Problems ",
                ImageUrl=@"blob:https://www.kobo.com/bd29cd9d-d96c-4d78-86a6-b3187a5aece3",
                Price = 98.06
            },

            new ProductModel{

                    Id= 4, Name="The Power of A Positive Attitude",
                Description= "Have you ever wondered how your attitude can influence your Success and failure? Have you ever considered the power of saying ‘I Can’, ‘I must’, ‘I will’? “I am not saying a positive attitude can make you successful. I am saying a positive attitude will make you successful.” – Norman Vincent Peale from helping you interpret and understand the true nature of your current attitude to building up self-confidence, which is a must for an affirmative attitude, this book details the dos and don’ts in dealing with your boss, provides handy tips for overcoming negative attitude, managing stress, and coping with burnout, and expounds on how converting negative thinking to positive action can bring about a change in life. Packed with powerful information, The power of a positive attitude will help you uncover your hidden abilities and achieve success.",
                ImageUrl=@"data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBwgHBgkIBwgKCgkLDRYPDQwMDRsUFRAWIB0iIiAdHx8kKDQsJCYxJx8fLT0tMTU3Ojo6Iys/RD84QzQ5OjcBCgoKDQwNGg8PGjclHyU3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3N//AABEIAKIAaAMBIgACEQEDEQH/xAAbAAACAwEBAQAAAAAAAAAAAAAABQMEBgIBB//EAD0QAAIBAwMBBQUFBQcFAAAAAAECAwAEEQUSITEGE0FRYRQicYGhFTKRsdEjQlJiwRYkM0OS4fE0RFST8P/EABsBAAIDAQEBAAAAAAAAAAAAAAIDAAEEBQcG/8QALxEAAQQBAwIDBwUBAQAAAAAAAQACAxEhBBIxE0EUUXEiMmGBkdHwBaHB4fGxM//aAAwDAQACEQMRAD8Aa0UUV9UvOkUUl1vXG0+5WCCJJHCb33MRnJwFXHVjzXB1+Vr0CO3U2azrbvKzYYyH+EeQ8aSZ2A0StTdHM5ocBgp7RWeGuXU8i3MCRx2BkKhpAdzquS758BgHHXNTS6vdW2lxXVzFD3twyiKPJUDP8R9Bzmp4hmVZ0UorzKd0VR0q/N5py3kyCIe8SQTggfvDPOPGlp1q8j05b6RICty4W3hOQQCeCzeHu5NWZmAAoW6WRzi0cg0tBRSGDVr3UIoVs1hgldXkeRwWTYDgEdDg+GajtNS1Y6eb+d7AWwLYL7kJAOMjGevlQ+Iaj8FIBmrWioqPSjNf2sUjQ91I67mRmxj5mmmoaa9nZ2czZ/bKSw/hOf0pnVaCBfKT0H041xyl9FFFMSUUVLbM6zoUjR2JwFdcgk+laOfTUvGKbIYkV9oaOIKSRgHn1JP4VnlnERAK1QaUzNJacr5ydJuf7RfapSORSTHsZvuLtGHX1zn8aqx6DeyW/s0xSCOFZjE4O7vJXJxIfQZ/GtbJHuumiiVhl9qg9evFbLVIdJ0/T7SPUI97RKAiL95j+lZpumwjBNrfpnTSNcbA20LPwXyH7J1SSzuITiGH2ZYI7cS7g2OrdMDIyPzqTV9Gu9Rt7RQAPZwXEcsgYO2RhWwMYxmt9q9pbzabDqtlCLdJHKNEOnUgEfhSSmRxMkb3SZtTNDIOPMfMKhqtvPd6TJbwBY3lUKRnAUHrj5ZpbrWgG5jt4bGGCOG3BcRkYV3yuAw8RjPNaGinvha7lZYtVJH7v5aST6fePb6m6BEnuVVIhu+4gUcZ9CWrq509xNYxrbCa0tUGyISADeOAWB64HT1pzRVdBqvxb7v84peDkDIxU5uZzAIDNIYgchCxxUNFN2g8rOHEcIooooqQqS3KieMu5jAYHeoyV9aZNf2qH3Jb6XxzvVec56YPiaU0Up8TXnKfHO6MU1O+zdst5rwdQ3dx5lO45Ppn5n6V52lle+19oYveKFYkHmfH6n6U27FxLDY3N2/AJxk+AAr3TLK2sDNrF9cxSFizIVORg+PxNc90wbM53kKC7DNM5+lY3jcdxPwUfaOMWukWOlwDdIzDCjqcf7mlF3oF5a2xnOxwg99UOStXrO7fUtWlvm4YYjhz/lg8k/IZPzo0jUll1G+kk3GJrdtoJ4Cjz+P9atjpYmkDtk/NDKyCd+53fDfQJPYabc6gszWyBhEuTk4+Vcew3PsHtxT9hu27vWtGVbTOzEEEIxdXxA9fe/2rztQohtLDSbXqSOPhwPrmmDVOc+hwT+w5SXaCNkRJ5A/c8LPjTrg+yFl/Z3RARh8fzFMdUsNMtro2UHtT3XAHIKhj0FaRYYYrjTbAe97LGZT8htH1OflSHTLa5n7TLc3NvKiPI7qWXA6HFLGoc+3E1Q+qc7RNiAYBZcQPTGVafs1p8ckcMl1KJ5V91Rjg+fTpmszdwG1upYGIJjYqSPGtxr15DpRa6K77qRdkQPhj/msHJI0rtJI252OSfM0zROkfbnHCV+qRwREMYKP8LmiiiuguOiiirttpl1c2b3MCb1VsFQDk/Cgc9rRZKNkbnmmi1ow4tOxAZOsiY/1Nj8jWQ8AMkgeHhTO4Oo2Onex3cJEEpBTePunrxSukaaPbuPNlbNbMX7G1VACk/wCzQjltb62DhLl0butxxklSKq3ca6ZaywKc3E4AYeKoPP1J8PKlQODkEgjx8qupp1zIqSkKFcFizN0GCcn5ChdEGvLnOweyjJ3OjDGM9od1otR1HTWksr8zCQQLiO3XqCepPwxXlzd6eL9tXluEnZVAggQ8g46nyrNWFlLe3IhhwDgkseAAKrcEcUDdIy6Dv8TnfqMtbiwUf+jun2lazm/vJ7ybu3uE2q+MhD4fKu9OvLHTtSFxJfTXTlCpcxnAz88+FZ+vKa7SsJPxSG6+RoFiyDdrTJqFrrOmS2t/OsU8bFopX4B8v0rNEYJGQeeoryimRQiKwDhKn1Dp6Lhkd/NFFFFOWZB6cda2l5ct2e0K1hhVfaJBjJ8D1JrN6Dbe1atbxMMqG3N8BzTbtSZNQ1uGxtxuZFAx5E85rBqC18rWO4GSutog6LTvlb7x9kL20aa+7N6nPfSNIfvIW8CB4fOsxWu7Qumn6Rb6RbcySYBA6kA/1NQmz0rTILe2voxLPPjcw6rnxHkBQQzBgLq5OB8EzU6UyOazdloyT5nssvTOTV8xSJDDtMkaoxZt3TjgY8qltNKU6xPDIw9ntSXkdv4RV29e11PRJJ4rdUkjnEUJAwxBxgH8abLKxzm2L/tZ4NNK1jiHUc486SS0vns4Zo40TMvDOeuMHj65qFIZZP8ADikcfyoTWj1SS30KSzjgtYZJxCe8Z1+GD9DTCLVJR2elv54YlYkiNcZB5wM5oDqCBvYz3k1uja4mOST3RfHHdYt45Eba8bq3kykGudpKkgHaOpx0rVaBO95Lc6rdpGq28ZVdq4HmarsBbdlprllCy3snHHhn9AaPxR3bSM4CV4EFm8OxRPHYfcpILSYyW6BMm4wY+eDk4qW+0q8sFDXMaqCeoYGnekQgXmnJIP8ApbZp29CxJA/Cs5czG4uJZ2/zHLc0Ucr3vocBLmgjii3Hk8fRRUUUVrWILT9hrfdc3Nwf3ECD5nn8vrXK9pIYbq6mWxRp2YhZV43LnjNedk9Rgtori1lYK8h3IxOAeOmflWcVSzBVUlieABkmuf0RJM/qDGF1jqnQ6WIRHOb9U40dpNU7QxyXT7mYlz8hwBUslvLd9rJEmGFjkDN5KigY+mPxpXBLcaZepLsaOaM52uMceVXr7WkmFwba3MU11gTyFsnGMYHkKJ8bt9sGCK9EuOaPpVKfaDrPxVmGdomutSlRXsLyUwumfeKnjIqSx0s2vaaO0EjNbgd+oJ6jwz65pXp+rSWcHs8kEVxDvDhJP3W869l1q8fU/b1ISQDaFA4C+VCYJbcBxX+IxqoKa52SDf3+S87RXJutWuX6hTsUfCm3aki003T9PTjau5vXAx+ZNZqRjK7u/V2LH4mpbm7nuihuJTIUXapPlTugbZ5NWbxYqW+XfdPpHFp2LQIcNcvg/ic/QVd1O1jl03TVYgWcMe+Rs8YwMVkTNKYRCZGMQbcEzwD5177RN3HcGVzFnOzcdv4Us6V13fclPGvZVFuNoH0Wh0e6Ey6tdtC0hdAoiXrt6ACkmoo6TKZLP2UFfdQZ5/GoYLia3YvbyvExGCUYjNcSSPIxaV2Zj4scmmMh2SFw4SJdSJYgw8hc0UUVqCxIxWq7MWcNta/aVyuZHISEH144rO2Nsby8ht1/zGAz5Dxrbvayvq1nEkQSxtEyvvDlsYHHpXP10lDZa6/6XBbuqRdYHr/Sqdo7EaneJGtxBD3K+9v6kn/ilt12YNvGWk1GANtJAYYz9aqXZ+0u0zL1D3AQfAHH9K77XzCXWWjH3YEVB8cZ/rQRNlaWxtd2vhM1D4JBJM5lm6GeVNYdm47tAftGIsVDFE5IqD7GilvobWzvY5i+d5XB2Yq1on9x0DUNQxiSQd3Gfp+Z+lc9mwLTTb/Uj9+Ne7jJ88frioZJBuO7jA9VTYYHCNuyrFnJ4H3UdlpmkGUQXWoSNOXKbI0PUHHkal1bTdJtZDaW7ztenAVScjJ6ZqHshbibVu9fpChck+ddaM41HtR37cgu0g+A6f0q37w93tHAtSMRviaAwW40PTzXcuhQDX4LCJ3KFN8ozyoo0zT7FPtO6uUMtnb5RATyefPzpvYxSRz6tqkylSxZYif4V4z9BS0wTy9mbK0t1LS3kpd8dMZJyfpSus5wou8h/JT/AA0bDuDM5IH7AfyqV1a2l3pcl9ZWzW3dSiPaXLB84/WrOtXL6bFa6fbrGCsIMpMYbJPhz/8Ac1YujbQTabokDhgkqtM3mc9PjVDtG0E15cSpDcvIGw0p4QY48qOM73gO4yfskzNEcbnNIDsA19SklFFFdRcVWtLuxYX8VyV3BDyPSmtjqlvbdobm7eUvFMjBWwfdJIIB/DFJIIJbiVYoULyN0UeNOYOyupSj9oIoh/O1ZJxDdvNWKW/SnUkARNujfzS3TrsWepxXbLvCOWIB69a51G4F3fT3C5xI5YA9cU3bs3bw8XWr20bDqoAJ/OuTY9n4f8XU5pSOojAx+VCJot25tk8cIjpdRs2OIAu8kKk+p79Dj07uyNkm7cOhGSf61xHqTppMmn7Bsdw+/PI9Ktz/ANnSm2L23I/eX/eoN2ijpHqDfFkFENhHuHm0L+oHf+g4rnsodN1GbT+/7kKRNHsYH6EVDZ3M1lOs1u+x16cVb73SfC0uz8ZR+led9pX/AIdz/wC8fpR2M+wcpVOwOoMcLuXXtQmaYySIVlTY0ZX3QPSuLXWL+0tvZ7eYiPnHu8rnyNBl0k/9teD4Sj9Kkjk0Mfftr4k/zrQbYwK6aaHyl19XPqlwkcSd6HbvN27cDznzqa51C8ul23FzI48ieKYhuzjkZjvI/TOaq6rHpqd22mTSuG+8jj7tEHtc4AtP0S3RPYwkSAj4FL6K9rytOFkXcUjwyLJE7I69GU8ipLi8uro/3i4lk9GY4/CoKKEtBN0iD3AbQcLxiqIWPAUZ+ApZHrAZlR7dkd9jIu7OVbPPyCk4q/dQrc20kDkhZFKkjqM1SXR4FQmSSVn94tKThjldvywOBS5N9+wnQdGj1OVWi12WaTC2LhAO8ZnkxiLj3+nqeP5TzXC69KwYG1VZCA0a7s5BHug+uSvH81QWh0y5aPZHczIISrO7DYVBJJPPONx6dM+nFmxhs50EtrbSySQqsg719u9nA6+oAX6VmDpDw5b3RwN5Z+fVcTa3cbbMWwhlku2dowAcKi+Zz15HPh5VF/aGXvGHdqiGMOhPU85I/wBBB+dRxXNofZopdMk24Ajfvg2xN20HORwSfmKv6lNY6fJGgsGmYAsSq8IuNuST5gYqg55F78KyyJpDTHn8+K702a6uo7h7i5CZUZSMDMDEE49cDFKxf3UUcLC9nkaZGkCMqkKrHbHnA/mB+VXrfUraF2tbPTzt3N3oXGFAwGJ88E4+RqW0v/aTbrDYKqy/4ZduDEOQenwwPUVZIcAA7KENLHElmPkrOjyPPZCWWRpGdife8BngD5Yq9ST7WlRHFpphwzlYQCF7zAJYkeHQ+tOxnAz1rVE4FtBYdRG5rtxFWiiiimrMiiiiqURUd1EZ7WaFXKGRCoYfu5HWpKKhF4Vg0bCSPoxjtWjE7tH7MbcKi8hST4Z56+XhU+k2UiaVLFMzrLOXLNjDDPC8eGABxTSilCFodYWh2qkc3afO0uXSIVnhcOwSNI1MeODszt/POPMCurnS1uLiSU3Eq749mwYwvI5+g46Vfoq+kyqpD4iS7tK4dDt4nLd5KwbdvUt97JJ588Emu4tGtozEcuzRqVyxBJGMfLAA6YpjRUEMY7Kzqpjy5L4tJgjMBDzEwuXXMnUk55phRRRNYG8JT5HyG3G0UUUUaBFFFFUoiiiiooiiiiooiiiiooiiiiooiiiiooiiiioov//Z",
                Price = 120.56
            }

        };

        public IActionResult GetProduct()
        {
            return Ok(pr);
        }


    }
}
