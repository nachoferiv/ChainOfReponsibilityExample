using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class InvalidSuperiorException : Exception
    {
        public InvalidSuperiorException(string message)
        : base(message)
        {
        }

    }

    public enum EnumVacationStatus
    {
        PENDING,
        APPROVED,
    }

    public class Vacation
    {
        private int _id;
        private int _numberOfDays;
        private string _reason;
        private string _requester;
        private IEmployee _currentApprover;
        private EnumVacationStatus _status;

        public Vacation(int numberOfDays, string reason, string requester, IEmployee currentApprover, EnumVacationStatus status = EnumVacationStatus.PENDING,int? id = null)
        {
            this._numberOfDays = numberOfDays;
            this._reason = reason;
            this._status = status;
            this._requester = requester;
            this._currentApprover = currentApprover;
            if (id != null) 
                this._id = (int)id;
        }

        public int GetID()
        {
            return _id;
        }


        public int GetNumberOfDays()
        {
            return _numberOfDays;
        }

        public string GetReason()
        {
            return _reason;
        }

        public string GetRequester() { return _requester; }
        public IEmployee GetCurrentApprover() { return _currentApprover; }

        public EnumVacationStatus GetStatus()
        {
            return _status;
        }

        public void Approve(IEmployee currentApprover)
        {
            this._status = EnumVacationStatus.APPROVED;
            this._currentApprover = currentApprover;
        }
    }

    public abstract class VacationHandler
    {
        protected VacationHandler Superior;

        public void SetSuperior(VacationHandler superior)
        {
            this.Superior = superior;
        }

        public abstract Vacation HandleVacation(Vacation vacation);
    }
}
