using oncontigo_platform.HealthTracking.Domain.Model.Aggregates;
using oncontigo_platform.HealthTracking.Domain.Model.Queries;
using oncontigo_platform.HealthTracking.Domain.Repositories;
using oncontigo_platform.HealthTracking.Domain.Services;

namespace oncontigo_platform.HealthTracking.Application.Internal.QueryServices
{
    public class PatientFollowUpQueryService(IPatientFollowUpRepository patientFollowUpRespository) : IPatientFollowUpQueryService
    {
        public async Task<IEnumerable<PatientFollowUp>> Handle(GetAllPatientFollowUpsByDoctorIdQuery query)
        {
            return await patientFollowUpRespository.ListByDoctorId(query.doctorId);
        }
    }
}
