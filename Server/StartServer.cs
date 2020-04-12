using Networking.Utils;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services;
using Services.Services;

namespace Server
{
    static class StartServer
    {
        public static void Main(string[] args)
        {
            ICaseRepository caseRepository = new CaseDbRepository();
            IDonorRepository donorRepository = new DonorDbRepository();
            IVolunteerRepository volunteerRepository = new VolunteerDbRepository();
            IDonationRepository donationRepository = new DonationDbRepository();
            
            CaseService caseService = new CaseService(caseRepository);
            DonorService donorService = new DonorService(donorRepository);
            VolunteerService volunteerService = new VolunteerService(volunteerRepository);
            DonationService donationService = new DonationService(donationRepository);
            
            IService serverService = new ServerService(caseService, donorService, volunteerService, donationService);
            
            SerialConcurrentServer server = new SerialConcurrentServer("127.0.0.1", 55555, serverService);

            server.Start();
            
        }
    }
}