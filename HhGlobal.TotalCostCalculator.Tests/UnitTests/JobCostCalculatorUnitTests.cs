using Xunit;
using Moq;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HhGlobal.TotalCostCalculator.BLL.Calculators;
using HhGlobal.TotalCostCalculator.BLL.Common;
using HhGlobal.TotalCostCalculator.BLL.Models;

namespace HhGlobal.TotalCostCalculator.Tests.UnitTests;

public class JobCostCalculatorUnitTests
{    
    Mock<IOptions<Configuration>> ConfigurationMock{ get; }

    Mock<ILogger<JobCostCalculator>> LoggerMock{ get; }

    IJobCostCalculator JobCostCalculator { get; }

    public JobCostCalculatorUnitTests()
    {
        //Configuration setup
        ConfigurationMock = new Mock<IOptions<Configuration>>();

        ConfigurationMock
            .Setup(configuration => configuration.Value)
            .Returns(new Configuration{
                SalesTax = 0.07,
                BaseMargin = 0.11,
                ExtraMargin = 0.05,
                NumOfFractionalDigits = 2
            });

        //Logger setup
        LoggerMock = new Mock<ILogger<JobCostCalculator>>();

        //JobCostCalculator initialization
        JobCostCalculator = new JobCostCalculator(ConfigurationMock.Object, LoggerMock.Object);
    }

    [Fact]
    public void CalculateJobCost_ShouldReturnJob_WithExtraMargin_ForItem_WithExtempt()
    {                       
        var job = new Job{
            IsExtraMargin = true,
            PrintItems = new List<PrintItem>{
                new PrintItem{
                    Name = "yoyo", 
                    Cost = 100,
                    IsExempt = true
                }
            }
        };

        var result = JobCostCalculator.CalculateJobCost(job);
        
        result.Should().BeEquivalentTo(new JobResult{
            PrintItems = new List<PrintItem>{
                new PrintItem{
                    Name = "yoyo", 
                    Cost = 100,
                    IsExempt = true
                }                
            },
            Total = 116
        });
    }

    [Fact]
    public void CalculateJobCost_ShouldReturnJob_WithExtraMargin_ForItem_WithoutExtempt()
    {                       
        var job = new Job{
            IsExtraMargin = true,
            PrintItems = new List<PrintItem>{
                new PrintItem{
                    Name = "yoyo", 
                    Cost = 100,
                    IsExempt = false
                }
            }
        };

        var result = JobCostCalculator.CalculateJobCost(job);
        
        result.Should().BeEquivalentTo(new JobResult{
            PrintItems = new List<PrintItem>{
                new PrintItem{
                    Name = "yoyo", 
                    Cost = 107,
                    IsExempt = false
                }                
            },
            Total = 123
        });
    }

    [Fact]
    public void CalculateJobCost_ShouldReturnJob_WithoutExtraMargin_ForItem_WithoutExtempt()
    {                       
        var job = new Job{
            IsExtraMargin = false,
            PrintItems = new List<PrintItem>{
                new PrintItem{
                    Name = "yoyo", 
                    Cost = 100,
                    IsExempt = false
                }
            }
        };

        var result = JobCostCalculator.CalculateJobCost(job);
        
        result.Should().BeEquivalentTo(new JobResult{
            PrintItems = new List<PrintItem>{
                new PrintItem{
                    Name = "yoyo", 
                    Cost = 107,
                    IsExempt = false
                }                
            },
            Total = 118
        });
    }

    [Fact]
    public void CalculateJobCost_ShouldReturnJob_WithExtraMargin_ForItem_WithoutExtempt_AndItem_WithExtempt()
    {                       
        var job = new Job{
            IsExtraMargin = true,
            PrintItems = new List<PrintItem>{
                new PrintItem{
                    Name = "envelopes", 
                    Cost = 520,
                    IsExempt = false
                },
                new PrintItem{
                    Name = "letterhead", 
                    Cost = 1983.37,
                    IsExempt = true
                }
            }
        };

        var result = JobCostCalculator.CalculateJobCost(job);
        
        result.Should().BeEquivalentTo(new JobResult{
            PrintItems = new List<PrintItem>{
                new PrintItem{
                    Name = "envelopes", 
                    Cost = 556.4,
                    IsExempt = false
                },
                new PrintItem{
                    Name = "letterhead", 
                    Cost = 1983.37,
                    IsExempt = true
                }                
            },
            Total = 2940.3
        });
    }

    [Fact]
    public void CalculateJobCost_ShouldReturnJob_WithExtraMargin_ForItem_WithExtempt_AndItem_WithExtempt()
    {                       
        var job = new Job{
            IsExtraMargin = true,
            PrintItems = new List<PrintItem>{
                new PrintItem{
                    Name = "frisbees", 
                    Cost = 19385.38,
                    IsExempt = true
                },
                new PrintItem{
                    Name = "yoyo", 
                    Cost = 1829,
                    IsExempt = true
                }
            }
        };

        var result = JobCostCalculator.CalculateJobCost(job);
        
        result.Should().BeEquivalentTo(new JobResult{
            PrintItems = new List<PrintItem>{
                new PrintItem{
                    Name = "frisbees", 
                    Cost = 19385.38,
                    IsExempt = true
                },
                new PrintItem{
                    Name = "yoyo", 
                    Cost = 1829,
                    IsExempt = true
                }                
            },
            Total = 24608.68
        });
    }
}