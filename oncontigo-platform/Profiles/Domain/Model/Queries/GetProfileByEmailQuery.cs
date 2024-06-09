using oncontigo_platform.Profiles.Domain.Model.ValueObjects;
using System.Net.Mail;

namespace oncontigo_platform.Profiles.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);
