using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace Docker.AspCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AWSController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            string secretName = "Product-Api-Keys";
            string region = "us-east-2";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
            };

            await Task.Delay(100);

            try
            {
                GetSecretValueResponse response = await client.GetSecretValueAsync(request);
                string secret = response.SecretString;
                return new List<string>() { secret };
            }
            catch (Exception e)
            {
                return new List<string>() { e.Message };
            }
        }
    }
}
