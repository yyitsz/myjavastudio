using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCrm.Model;
using SimpleCrm.Facade;
using SimpleCrm.Manager;

namespace SimpleCrm.ScheduleForm
{
    public class AppointmentInfoCache
    {
        private Dictionary<long?, AppointmentInfo> cache = new Dictionary<long?, AppointmentInfo>();
        private Dictionary<DateTime, bool> months = new Dictionary<DateTime, bool>();

        private bool IsLoad(AppointmentInfo ai)
        {
            return cache.ContainsKey(ai.AppointmentInfoId);
        }

        private bool IsMonthLoad(DateTime startDateOfMonth)
        {
            return months.ContainsKey(startDateOfMonth);
        }

        public void GetAppointmentListByMonth(DateTime startDate, Action<AppointmentInfo> action)
        {
            DateTime firstDayOfMonth = new DateTime(startDate.Year, startDate.Month, 1);
            if (IsMonthLoad(firstDayOfMonth))
            {
                return;
            }
            List<AppointmentInfo> appointmentInfoList = AppFacade.Facade.GetListByDateRange(UserManager.UserProfile.UserId, firstDayOfMonth, firstDayOfMonth.AddMonths(1).AddDays(-1));
            months[firstDayOfMonth] = true;
            appointmentInfoList.ForEach(a =>
            {
                if (IsLoad(a) == false)
                {
                    action(a);
                    cache[a.AppointmentInfoId] = a;
                }
            });
        }

        public void GetAppointmentListByMonth(DateTime startDate, DateTime endDate, Action<AppointmentInfo> action)
        {
            DateTime firstDayOfFirstMonth = new DateTime(startDate.Year, startDate.Month, 1);
            DateTime firstDayOfEndMonth = new DateTime(endDate.Year, endDate.Month, 1);
            for (int i = 0; i < (firstDayOfEndMonth.Month - firstDayOfFirstMonth.Month + 12) % 12 + 1; i++)
            {
                DateTime month = firstDayOfFirstMonth.AddMonths(i);
                if (IsMonthLoad(month) == false)
                {
                    List<AppointmentInfo> appointmentInfoList = AppFacade.Facade.GetListByDateRange(UserManager.UserProfile.UserId, month, month.AddMonths(1).AddDays(-1));
                    months[month] = true;
                    appointmentInfoList.ForEach(a =>
                    {
                        if (IsLoad(a) == false)
                        {
                            action(a);
                            cache[a.AppointmentInfoId] = a;
                        }
                    });
                }
            }
        }

        public void GetAppointmentOf12Month(DateTime date, Action<AppointmentInfo> action)
        {
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            DateTime endDayOfMonth = firstDayOfMonth.AddMonths(12).AddDays(-1);
            for (int i = 0; i < 12; i++)
            {
                months[firstDayOfMonth.AddMonths(i)] = true;
            }
            List<AppointmentInfo> appointmentInfoList = AppFacade.Facade.GetListByDateRange(UserManager.UserProfile.UserId, firstDayOfMonth, endDayOfMonth);
            months[firstDayOfMonth] = true;
            appointmentInfoList.ForEach(a =>
            {
                if (IsLoad(a) == false)
                {
                    action(a);
                    cache[a.AppointmentInfoId] = a;
                }
            });
        }

        public void SaveAppointmentInfo(AppointmentInfo ai)
        {
            bool isNew = ai.IsNew();
            AppFacade.Facade.SaveAppointmentInfo(ai);
            if (isNew)
            {
                cache[ai.AppointmentInfoId] = ai;
            }
        }

        public void DeleteAppointmentInfo(AppointmentInfo ai)
        {
            bool isNew = ai.IsNew();
            AppFacade.Facade.DeleteAppointmentInfo(ai);
            cache.Remove(ai.AppointmentInfoId);
        }
    }
}
