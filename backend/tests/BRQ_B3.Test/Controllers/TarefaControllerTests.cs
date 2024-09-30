using AutoMapper;
using BRQ_B3.Api.ViewModels;
using BRQ_B3.API.Controllers;
using BRQ_B3.Business.Intefaces;
using BRQ_B3.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class CalculoCDBControllerTests
{
    private readonly Mock<ICalculoCDBRepository> _mockRepository;
    private readonly Mock<ICalculoCDBService> _mockService;
    private readonly IMapper _mapper;
    private readonly CalculoCDBController _controller;

    public CalculoCDBControllerTests()
    {
        _mockRepository = new Mock<ICalculoCDBRepository>();
        _mockService = new Mock<ICalculoCDBService>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CDBCalculoViewModel, CalculoCDB>();
            cfg.CreateMap<CalculoCDB, CDBResultViewModel>();
        });

        _mapper = config.CreateMapper();
        _controller = new CalculoCDBController(_mockRepository.Object, _mockService.Object, _mapper);
    }

    [Fact]
    public async Task GetAll_ReturnsListOfCDBResultViewModel()
    {
        var mockResults = new List<CalculoCDB>
        {
            new CalculoCDB 
            {  
                Cdi = 1,
                TaxaBanco = 1,
                ValorInicial = 1,
                ValorFinal = 1,
                Meses = 1,
            }
        };

        _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(mockResults);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<CDBResultViewModel>>(okResult.Value);
        Assert.Single(returnValue);
    }

    [Fact]
    public async Task GetId_ReturnsCDBResultViewModel_WhenExists()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var mockResult = new CalculoCDB
        {
            Cdi = 1,
            TaxaBanco = 1,
            ValorInicial = 1,
            ValorFinal = 1,
            Meses = 1,
        };

        _mockRepository.Setup(repo => repo.GetId(guid)).ReturnsAsync(mockResult);

        // Act
        var result = await _controller.GetId(guid);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<CDBResultViewModel>(okResult.Value);
        Assert.NotNull(returnValue);
    }

    [Fact]
    public async Task Add_ReturnsCDBResultViewModel_WhenSuccess()
    {
        // Arrange
        var viewModel = new CDBCalculoViewModel {  };
        var mockResult = new CalculoCDB
        {
            Cdi = 1,
            TaxaBanco = 1,
            ValorInicial = 1,
            ValorFinal = 1,
            Meses = 1,
        };

        _mockService.Setup(service => service.Add(It.IsAny<CalculoCDB>())).ReturnsAsync(mockResult);

        // Act
        var result = await _controller.Add(viewModel);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<CDBResultViewModel>(okResult.Value);
        Assert.NotNull(returnValue);
    }

    [Fact]
    public async Task Update_ReturnsCDBResultViewModel_WhenSuccess()
    {
        // Arrange
        var viewModel = new CDBCalculoViewModel {  };
        var mockResult = new CalculoCDB
        {
            Cdi = 1,
            TaxaBanco = 1,
            ValorInicial = 1,
            ValorFinal = 1,
            Meses = 1,
        };

        _mockService.Setup(service => service.Update(It.IsAny<CalculoCDB>())).ReturnsAsync(mockResult);

        // Act
        var result = await _controller.Update(viewModel);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<CDBResultViewModel>(okResult.Value);
        Assert.NotNull(returnValue);
    }

    [Fact]
    public async Task Delete_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        var guid = Guid.NewGuid();
        _mockService.Setup(service => service.Delete(guid)).ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(guid);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.True((bool)okResult.Value);
    }
}
