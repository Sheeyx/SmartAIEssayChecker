using System.Linq.Expressions;
using Moq;
using MyNamespace.Brokers.Loggings;
using MyNamespace.Services.Users;
using SmartAIEssayChecker.Brokers.Storages;
using Xeptions;

namespace SmartAIEssayChecker.Tests.Unit.Services.Foundations.Users;

public partial class UserServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly Mock<ILoggingBroker> loggingBrokerMock;
    private readonly IUserService userService;

    public UserServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.loggingBrokerMock = new Mock<ILoggingBroker>();

        this.userService =
            new UserService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
    }

    private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
        actualException => actualException.SameExceptionAs(expectedException);


  
}