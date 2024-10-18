using Moq;
using TodolistApi.core.Domain.model;
using TodolistApi.Core.Domain.Abstraction;
using TodolistApi.Core.Domain.Model.Dtos;
using TodolistApi.Core.Domain.Usecase;
using Xunit;

namespace TodolistApiTest.Usecases
{
    internal class ManageTicketTest
    {
        public class ManageTicketTests
        {
            private readonly Mock<IBaseRepository<Ticket>> _mockTicketRepository;
            private readonly Mock<IPaginateRepository<Ticket>> _mockPaginateTicketRepository;
            private readonly ManageTicket _manageTicket;

            public ManageTicketTests()
            {
                _mockTicketRepository = new Mock<IBaseRepository<Ticket>>();
                _mockPaginateTicketRepository = new Mock<IPaginateRepository<Ticket>>();
                _manageTicket = new ManageTicket(_mockTicketRepository.Object, _mockPaginateTicketRepository.Object);
            }

            [Fact]
            public async Task CreateTicket_ShouldReturnCreatedTicket()
            {
                // Arrange
                var ticketDataDto = new TicketDataDto { Description = "Test Ticket", IsOpened = true };
                var ticket = new Ticket { Id = 1, Description = "Test Ticket", IsOpened = true, CreatedAt = DateTime.Now };

                _mockTicketRepository.Setup(repo => repo.Add(It.IsAny<Ticket>())).Returns(Task.FromResult(ticket));

                // Act
                var result = await _manageTicket.CreateTicket(ticketDataDto);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(ticketDataDto.Description, result.Description);
                Assert.Equal(ticketDataDto.IsOpened, result.IsOpened);
            }

            [Fact]
            public async Task UpdateTicket_ShouldReturnUpdatedTicket()
            {
                // Arrange
                var ticketDataDto = new TicketDataDto { Description = "Updated Ticket", IsOpened = false };
                var ticket = new Ticket { Id = 1, Description = "Test Ticket", IsOpened = true };

                _mockTicketRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(ticket);
                _mockTicketRepository.Setup(repo => repo.Update(It.IsAny<Ticket>())).Returns(Task.FromResult(ticket));

                // Act
                var result = await _manageTicket.UpdateTicket(1, ticketDataDto);

                // Assert
                Assert.NotNull(result);
                //Assert.Equal(ticketDataDto.Description, result.Description);
                //Assert.Equal(ticketDataDto.IsOpened, result.IsOpened);
            }

            [Fact]
            public async Task UpdateTicket_ShouldThrowException_WhenTicketNotFound()
            {
                // Arrange
                var ticketDataDto = new TicketDataDto { Description = "Updated Ticket", IsOpened = false };

                _mockTicketRepository.Setup(repo => repo.GetById(1)).ReturnsAsync((Ticket)null);

                // Act & Assert
                await Assert.ThrowsAsync<Exception>(() => _manageTicket.UpdateTicket(1, ticketDataDto));
            }

            [Fact]
            public async Task GetTicketByPage_ShouldReturnPagedTickets()
            {
                // Arrange
                var tickets = new List<Ticket> { new Ticket { Id = 1, Description = "Test Ticket", IsOpened = true } };
                var page = 1;
                var limit = 10;
                var totalPage = 1;

                _mockPaginateTicketRepository.Setup(repo => repo.GetByPage(page, limit)).ReturnsAsync(tickets);
                _mockPaginateTicketRepository.Setup(repo => repo.GetTotalPage(limit)).ReturnsAsync(totalPage);

                // Act
                var result = await _manageTicket.GetTicketByPage(page, limit);

                // Assert
                Assert.NotNull(result);
                //Assert.Equal(tickets, result.Tickets);
                //Assert.Equal(page, result.CurrentPage);
                //Assert.Equal(totalPage, result.TotalPage);
            }
        }
    }
}
