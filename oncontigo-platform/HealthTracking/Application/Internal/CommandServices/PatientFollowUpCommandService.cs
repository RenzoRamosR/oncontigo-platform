using oncontigo_platform.HealthTracking.Application.Internal.OutbondServices.ACL;
using oncontigo_platform.HealthTracking.Domain.Model.Aggregates;
using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Domain.Repositories;
using oncontigo_platform.HealthTracking.Domain.Services;
using oncontigo_platform.Shared.Domain.Repositories;

namespace oncontigo_platform.HealthTracking.Application.Internal.CommandServices
{
    public class PatientFollowUpCommandService(IPatientFollowUpRepository patientFollowUpRepository, IExternalProfileService externalProfileService, IUnitOfWork unitOfWork) : IPatientFollowUpCommandService
    {
        public async Task<PatientFollowUp?> Handle(CreatePatientFollowUpCommand command)
        {
            
            var patientId = await externalProfileService.FetchPatientIdById(command.patientId);
            var doctorId = await externalProfileService.FetchDoctorIdById(command.doctorId);

            if (patientId == null || doctorId==null) { return null; }

            var patientFollowUpE = await patientFollowUpRepository.FindByPatientId(command.patientId);
            if (patientFollowUpE != null) { return null; }

            var patientFollowUp = new PatientFollowUp(patientId,doctorId,command.status);
            await patientFollowUpRepository.AddAsync(patientFollowUp);
            await unitOfWork.CompleteAsync();
            return patientFollowUp;
        }

        public async Task<PatientFollowUp?> Handle(RemovePatientFollowUpByPatientId command)
        {
            var patientFollowUp = await patientFollowUpRepository.FindByPatientId(command.patientId);
            if (patientFollowUp == null) { return null; }

            patientFollowUpRepository.Remove(patientFollowUp);
            await unitOfWork.CompleteAsync();
            return patientFollowUp;

        }
    }
}
