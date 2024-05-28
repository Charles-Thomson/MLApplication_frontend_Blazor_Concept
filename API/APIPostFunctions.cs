namespace MLApplication_frontend.API
{
    public class APIPostFunctions
    {

        private readonly HttpClient _client;
        public APIPostFunctions(HttpClient newClient)
        {
            _client = newClient ?? throw new ArgumentNullException(nameof(newClient));
        }

        public async Task<string> PostRequest(string query)
        {

            try
            {
                HttpResponseMessage response = await _client.GetAsync(query);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return string.Empty;
            }

        }

        /// <summary>
        /// New post request to the Backend API - Submitting a new work item
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns>String - JSon of the Environment and Alpha Agent</returns>
        public async Task PostNewWorkItem(string formattedInstanceStateData)
        {
            await PostRequest(formattedInstanceStateData);
        }
    }
}
