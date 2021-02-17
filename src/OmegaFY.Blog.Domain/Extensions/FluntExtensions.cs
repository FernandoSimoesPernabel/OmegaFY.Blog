using Flunt.Validations;
using OmegaFY.Blog.Domain.Exceptions;
using System;
using System.Linq;

namespace OmegaFY.Blog.Domain.Extensions
{

    public static class FluntExtensions
    {

        public static string NotificationsToSingleMessage<T>(this Contract<T> contract)
        {
            return contract.IsValid ?
                string.Empty :
                string.Join(Environment.NewLine, contract.Notifications.Select(notification => notification.Message));
        }

        public static Contract<T> EnsureContractIsValid<T>(this Contract<T> contract)
            => EnsureContractIsValid<T, DomainArgumentException>(contract);

        public static Contract<T> EnsureContractIsValid<T, TException>(this Contract<T> contract) where TException : Exception
        {
            if (contract.IsValid)
                return contract;

            throw (TException)Activator.CreateInstance(typeof(TException), new object[] { contract.NotificationsToSingleMessage() });
        }

        public static Contract<T> IsBetweenLength<T>(this Contract<T> contract, string val, int min, int max, string property, string message)
        {
            val ??= string.Empty;

            if (!(val.Length >= min && val.Length <= max))
                contract.AddNotification(property, message);

            return contract;
        }

    }

}
