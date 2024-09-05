using Polly;
using Polly.CircuitBreaker;

namespace EmployeeManagementApi.Helper.Policies
{
    public class MessagingPolicies
    {
        private static readonly AsyncCircuitBreakerPolicy _circuitBreaker = Policy.Handle<Exception>()
            .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30),
               
                onBreak: (exception, timespan) =>
                {
                    // Log or handle the circuit being open
                    Console.WriteLine("Circuit Breaker Status : Open");

                },
                onReset: () =>
                {
                    // Log or handle the circuit being reset
                    Console.WriteLine("Circuit Breaker Status : CLose");
                });

        public static AsyncCircuitBreakerPolicy CircuitBreaker => _circuitBreaker;
    }

}
