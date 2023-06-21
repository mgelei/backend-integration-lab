using FluentAssertions;
using Lottery.API.Controllers;
using Lottery.API.Repositories;
using Lottery.Model;
using Lottery.Model.DTO;
using Moq;
using TestAPI.Common;
using TestAPI.MockData;

namespace TestAPI;

public class TestDrawController
{
    [Fact]
    public async Task GetDraws_ShouldReturnAllDraws()
    {
        var mockData = new DrawsMockData();
        var mockRepo = new Mock<DrawRepository>(MemoryContext.GetMemoryContext()); 
        mockRepo.Setup(_ => _.GetDrawsAsync()).ReturnsAsync(new DrawsMockData().GetDraws());
        var controller = new DrawController(mockRepo.Object);
 
        mockData.GetDraws().Count.Should().Be(3);
    }
    
    [Fact]
    public async Task PostDraws_ShouldCreateNewDraw()
    {
        var mockData = new DrawsMockData();
        var mockRepo = new Mock<DrawRepository>(MemoryContext.GetMemoryContext());
        var numbers = new List<int> { 31, 32, 33, 34, 35 };
        
        mockRepo.Setup(_ => _.GetDrawsAsync()).ReturnsAsync(mockData.GetDraws());
        mockRepo.Setup(_ => _.AddDrawAsync(It.IsAny<DrawPost>()))
            .Callback((DrawPost draw) => mockData.CreateDraw(new Draw
            {
                Id = mockData.GetDraws().Count + 1,
                Numbers = numbers,
                CreatedAt = DateTime.Now,
            }))
            .Returns(Task.CompletedTask);
        var controller = new DrawController(mockRepo.Object);
 
        var result = await controller.PostDraw(new DrawPost()
        {
            Numbers = numbers,
        });

        mockData.GetDraws().Count.Should().Be(4);
    }
}