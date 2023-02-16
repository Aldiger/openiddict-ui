using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OpenIddict.UI.Api;
using Xunit;

namespace OpenIddict.UI.Tests.Unit;

public class ScopeControllerTest
{
  [Fact]
  public async Task GetAsyncWithNullIdReturnsBadRequest()
  {
    // Arrange
    var controller = GetController();

    // Act
    var result = await controller.GetAsync(null);

    // Assert
    Assert.NotNull(result);
    Assert.IsType<BadRequestResult>(result);
  }

  [Fact]
  public async Task GetAsyncWithNotExistingIdReturnsNotFound()
  {
    // Arrange
    var serviceMock = new Mock<IScopeApiService>();
    var controller = GetController(serviceMock);
    var id = "id";

    serviceMock
      .Setup(r => r.GetAsync(id))
      .Returns(Task.FromResult<ScopeViewModel>(null));

    // Act
    var result = await controller.GetAsync(id);

    // Assert
    Assert.NotNull(result);
    Assert.IsType<NotFoundResult>(result);
  }

  [Fact]
  public async Task CreateAsyncWithNullModelReturnsBadRequest()
  {
    // Arrange
    var controller = GetController();

    // Act
    var result = await controller.CreateAsync(null);

    // Assert
    Assert.NotNull(result);
    Assert.IsType<BadRequestResult>(result);
  }

  [Fact]
  public async Task CreateAsyncWithInvalidModelReturnsBadRequest()
  {
    // Arrange
    var controller = GetController();
    var model = new ScopeViewModel
    {
      // Name // required
    };

    // ModelState must be manually adjusted
    controller.ModelState.AddModelError(string.Empty, "Name required!");

    // Act
    var result = await controller.CreateAsync(model);

    // Assert
    Assert.NotNull(result);
    Assert.IsType<BadRequestObjectResult>(result);
  }

  [Fact]
  public async Task UpdateAsyncWithNullModelReturnsBadRequest()
  {
    // Arrange
    var controller = GetController();

    // Act
    var result = await controller.UpdateAsync(null);

    // Assert
    Assert.NotNull(result);
    Assert.IsType<BadRequestResult>(result);
  }

  [Fact]
  public async Task UpdateAsyncWithInvalidModelReturnsBadRequest()
  {
    // Arrange
    var controller = GetController();
    var model = new ScopeViewModel
    {
      // Name // required
    };

    // ModelState must be manually adjusted
    controller.ModelState.AddModelError(string.Empty, "Name required!");

    // Act
    var result = await controller.UpdateAsync(model);

    // Assert
    Assert.NotNull(result);
    Assert.IsType<BadRequestObjectResult>(result);
  }

  [Fact]
  public async Task DeleteAsyncWithNullModelReturnsBadRequest()
  {
    // Arrange
    var controller = GetController();

    // Act
    var result = await controller.DeleteAsync(null);

    // Assert
    Assert.NotNull(result);
    Assert.IsType<BadRequestResult>(result);
  }

  private static ScopeController GetController(Mock<IScopeApiService> service = null)
  {
    service ??= new Mock<IScopeApiService>();

    return new ScopeController(service.Object);
  }
}
