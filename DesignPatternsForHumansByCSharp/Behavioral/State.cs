namespace Behavioral
{
    public class State
    {
        public interface IPhoneState
        {
            IPhoneState pickUp();
            IPhoneState hangUp();
            IPhoneState dial();
        }

        public class PhoneStateIdle : IPhoneState
        {
            public IPhoneState pickUp()
            {
                return new PhoneStatePickedUp();
            }

            public IPhoneState hangUp()
            {
                throw new Exception("Phone is already idle");
            }
            
            public IPhoneState dial()
            {
                throw new Exception("unable to dial in idle state");
            }
        }

        public class PhoneStatePickedUp : IPhoneState
        {
            public IPhoneState pickUp()
            {
                throw new Exception("Phone is already picked up");
            }
            
            public IPhoneState hangUp()
            {
                return new PhoneStateIdle();
            }

            public IPhoneState dial()
            {
                return new PhoneStateCalling();
            }
        }

        public class PhoneStateCalling : IPhoneState
        {
            public IPhoneState pickUp()
            {
                throw new Exception("already picked up");
            }
            
            public IPhoneState hangUp()
            {
                return new PhoneStateIdle();
            }

            public IPhoneState dial()
            {
                throw new Exception("already dialing");
            }
        }

        public class Phone 
        {
           private   IPhoneState _state;

            public Phone()
            {
                _state = new PhoneStateIdle();
            }

            public void PickUp()
            {
                Console.WriteLine("picking up phone");
                _state = _state.pickUp();
            }

            public void HangUp()
            {
                Console.WriteLine("hanging up phone");
                _state = _state.hangUp();
            }
            
            public void Dial()
            {
                Console.WriteLine("dialing phone");
                _state = _state.dial();
            }
            
        }
        
        public static void DemonstrateState()
        {
            var phone = new Phone();
            phone.PickUp();
            // phone.PickUp();
            phone.Dial();
            phone.HangUp();
        }
        
        
        
    }

}

