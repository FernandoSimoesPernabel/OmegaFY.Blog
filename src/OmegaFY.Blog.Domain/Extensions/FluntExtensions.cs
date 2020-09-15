using Flunt.Validations;
using OmegaFY.Blog.Domain.Exceptions;
using System;
using System.Linq;

namespace OmegaFY.Blog.Domain.Extensions
{

    public static class FluntExtensions
    {

        public static string NotificationsToSingleMessage(this Contract contract)
        {
            return contract.Valid ?
                string.Empty :
                string.Join(Environment.NewLine, contract.Notifications.Select(notification => notification.Message));
        }

        public static Contract EnsureContractIsValid(this Contract contract) 
            => EnsureContractIsValid<DomainArgumentException>(contract);

        public static Contract EnsureContractIsValid<TException>(this Contract contract) where TException : Exception
        {
            if (contract.Invalid)
                throw (TException)Activator.CreateInstance(typeof(TException), new object[] { contract.NotificationsToSingleMessage() });

            return contract;
        }

        public static Contract IsBetween(this Contract contract, string val, int min, int max, string property, string message)
        {
            val ??= string.Empty;

            if (!(val.Length >= min && val.Length <= max))
                contract.AddNotification(property, message);

            return contract;
        }

    }

}
