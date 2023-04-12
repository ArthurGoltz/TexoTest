using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TexoTest.Controllers;
using TexoTest.Repository;
using TexoTest.Service;

namespace TexoTestTests
{
    public class TexoUnitTests
    {
        private readonly Mock<IMovieRepository> _movieRepository;
        private readonly Mock<ICSVService> _csvService;
        public MoviesController _moviesController;

        public TexoUnitTests()
        {
            _movieRepository = new Mock<IMovieRepository>();
            _csvService = new Mock<ICSVService>();
            _moviesController = new MoviesController(_movieRepository.Object);
        }



        //[Fact]
        //public async Task TestFileUploadMovieControllerAsync()
        //{
        //    //arrange
        //    var fileMock = new Mock<IFormFileCollection>();
        //    using (var ms = new MemoryStream())
        //    {
        //        using (var writer = new StreamWriter("dummy.txt"))
        //        {
        //            writer.WriteLine("dummy text");
        //            writer.Flush();
        //            ms.Position = 0;
        //            fileMock.Setup(m => m[0].OpenReadStream()).Returns(ms);
        //        }
        //    }

        //    //act
        //    var response = await _moviesController.FileUpload(fileMock.Object);
        //    var okResult = response as OkObjectResult;

        //    //assert
        //    Assert.Equal(200, okResult.StatusCode);
        //}
    }
}