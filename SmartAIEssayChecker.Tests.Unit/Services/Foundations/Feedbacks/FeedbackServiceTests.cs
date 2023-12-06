using Moq;
using MyNamespace.Brokers.Loggings;
using MyNamespace.Services.Feedbacks;
using SmartAIEssayChecker.Brokers.Storages;

namespace SmartAIEssayChecker.Tests.Unit.Services.Foundations.Feedbacks;

public partial class FeedbackServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly Mock<ILoggingBroker> loggingBrokerMock;
    private readonly IFeedbackService feedbackService;

    public FeedbackServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.loggingBrokerMock = new Mock<ILoggingBroker>();

        this.feedbackService =
            new FeedbackService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
    }

   
}