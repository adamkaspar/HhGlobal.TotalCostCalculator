using Xunit;
using FluentAssertions;
using System.Net.Http.Json;
using HhGlobal.TotalCostCalculator.API.Dto;
using HhGlobal.TotalCostCalculator.BLL.Models;

namespace HhGlobal.TotalCostCalculator.Tests.IntegrationTests;

public class JobCostCalculatorIntegrationTests
{        
    const string BASE_ADDRESS = "http://localhost:5121/";
    const string BASE_URI = "api/v1/TotalCostCalculator/CalculateTotalCost";

    HttpClient HttpClient{ get; }

    public JobCostCalculatorIntegrationTests()
    {
        HttpClient = new HttpClient(){
            BaseAddress = new Uri(BASE_ADDRESS)
        };
    }

    [Fact]
    public async Task CalculateJobCost_ShouldReturnJob_WithExtraMargin_ForItem_WithExtempt()
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

        var result = await PostJobAsync(job);
        
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
    public async Task CalculateJobCost_ShouldReturnJob_WithExtraMargin_ForItem_WithoutExtempt()
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

        var result = await PostJobAsync(job);
        
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
    public async Task CalculateJobCost_ShouldReturnJob_WithoutExtraMargin_ForItem_WithoutExtempt()
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

        var result = await PostJobAsync(job);
        
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
    public async Task CalculateJobCost_ShouldReturnJob_WithExtraMargin_ForItem_WithoutExtempt_AndItem_WithExtempt()
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

        var result = await PostJobAsync(job);
        
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
    public async Task CalculateJobCost_ShouldReturnJob_WithExtraMargin_ForItem_WithExtempt_AndItem_WithExtempt()
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

        var result = await PostJobAsync(job);
        
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

    private async Task<JobResultDto> PostJobAsync(Job job)
    {
        using var response = await HttpClient.PostAsJsonAsync(BASE_URI, job);
        var result = await response.Content.ReadFromJsonAsync<JobResultDto>();

        return result;
    }
}