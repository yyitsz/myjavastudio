using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar.Schedule;
using DevComponents.DotNetBar;
using DevComponents.Schedule.Model;
using SimpleCrm.Model;
using SimpleCrm.Facade;
using SimpleCrm.Manager;
using SimpleCrm.Utils;
using System.Collections.Generic;

namespace SimpleCrm.ScheduleForm
{
    public partial class ScheduleMainForm : BaseForm
    {
        #region Private variables

        private bool _UserStyleSet;
        private AppointmentInfoCache appointmentInfoCache = new AppointmentInfoCache();
        #endregion

        public ScheduleMainForm()
        {
            InitializeComponent();

            // Set our Calendar Model

            calendarView.CalendarModel = new CalendarModel();

            // Hook onto the following events so we can be receive
            // appointment StartTime and Reminder notifications

            calendarView.AppointmentReminder += AppointmentReminder;
            calendarView.AppointmentStartTimeReached += AppointmentStartTimeReached;

            // Uncomment out the following lines of code it you want to
            // see appointment move and resize events as they are processed

            //calendarView1.CalendarModel.AppointmentAdded += new AppointmentEventHandler(ModelAppointmentAdded);
            //calendarView1.CalendarModel.AppointmentRemoved += new AppointmentEventHandler(ModelAppointmentRemoved);
            //calendarView1.AppointmentViewChanged += new EventHandler<AppointmentViewChangedEventArgs>(AppointmentViewChanged);
        }

        #region Handled events

        /// <summary>
        /// Event sent when an appointment is added to the Model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ModelAppointmentAdded(object sender, AppointmentEventArgs e)
        {
            //Console.WriteLine(@"{0} New Appointment Added. Appointment Subject: {1}",
            //    DateTime.Now, e.Appointment.Subject);
        }

        /// <summary>
        /// Event sent when an appointment is removed from the Model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ModelAppointmentRemoved(object sender, AppointmentEventArgs e)
        {
            //Console.WriteLine(@"{0} Appointment Removed. Appointment Subject: {1}",
            //    DateTime.Now, e.Appointment.Subject);
        }

        /// <summary>
        /// Event sent when an appointment is either moved or resized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AppointmentViewChanged(object sender, AppointmentViewChangedEventArgs e)
        {
            //AppointmentView view = e.CalendarItem as AppointmentView;

            //if (view != null)
            //{
            //    string sOperation = (e.eViewOperation == eViewOperation.AppointmentMove)
            //        ? "Moved" : "Resized";

            //    Console.WriteLine(@"{0} Appointment {1}. Appointment Subject: {2}",
            //        DateTime.Now, sOperation, view.Appointment.Subject);
            //}
        }

        /// <summary>
        /// Event sent when an appointment reminder is reached
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AppointmentReminder(object sender, ReminderEventArgs e)
        {
            string s = string.Format(
                "Appointment Reminder reached for Appointment: '{0}'",
                e.Reminder.Appointment.Subject);

            MessageBoxHelper.ShowPrompt(s);
        }

        /// <summary>
        /// Event sent when an appointment StartTime is reached
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AppointmentStartTimeReached(object sender, AppointmentEventArgs e)
        {
            string s = string.Format(
                "Appointment StartTime Reached for Appointment: '{0}'",
                e.Appointment.Subject);

            MessageBoxHelper.ShowPrompt(s);
        }

        #endregion


        #region View change

        /// <summary>
        /// Day view selection
        /// </summary>
        /// <param name="sender">PopupItem</param>
        /// <param name="e">EventArgs</param>
        private void BtnDayClick(object sender, EventArgs e)
        {
            ButtonItem control = sender as ButtonItem;
            if (control != null && control.Tag != null)
            {
                eCalendarView view;
                if (Enum.TryParse<eCalendarView>(control.Tag as String, out view))
                {
                    calendarView.SelectedView = view;
                }
            }
        }

        #endregion

        #region CalendarView1ItemDoubleClick

        /// <summary>
        /// Handles Appointment View double clicks
        /// </summary>
        /// <param name="sender">AppointmentView</param>
        /// <param name="e">MouseEventArgs</param>
        private void CalendarView_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                AppointmentView item = sender as AppointmentView;

                if (item != null)
                {
                    Appointment ap = item.Appointment;
                    EditAppointment(ap);
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        #endregion

        #region CalendarView1MouseUp

        /// <summary>
        /// Handles CalendarView MouseUp events
        /// </summary>
        /// <param name="sender">Varied sender</param>
        /// <param name="e">MouseEventArgs</param>
        private void CalendarView_MouseUp(object sender, MouseEventArgs e)
        {
            // Process Right MouseUp event in order to
            // present view specific ContextMenu

            if (e.Button == MouseButtons.Right)
            {
                // Main Calendar View hit

                if (sender is BaseView)
                    BaseViewMouseUp(sender, e);

                // AppointmentView hit

                else if (sender is AppointmentView)
                    AppointmentViewMouseUp(sender);

                // AllDayPanel hit

                else if (sender is AllDayPanel)
                    AllDayPanelMouseUp(sender);

                // TimeRulerPanel

                else if (sender is TimeRulerPanel)
                    TimeRulerPanelMouseUp();

                // TimeLineHeaderPanel

                else if (sender is TimeLineHeaderPanel)
                    TimeLineHeaderPanelMouseUp(sender, e);
            }
        }

        #region BaseViewMouseUp

        /// <summary>
        /// Handles Day, Week, Month, Year, and TimeLine View MouseUp events
        /// </summary>
        /// <param name="sender">BaseView</param>
        /// <param name="e">MouseEventArgs</param>
        private void BaseViewMouseUp(object sender, MouseEventArgs e)
        {
            BaseView view = sender as BaseView;

            if (view != null)
            {
                eViewArea area = view.GetViewAreaFromPoint(e.Location);

                switch (area)
                {
                    case eViewArea.InContent:
                        InContentMouseUp(view, e);
                        break;

                    case eViewArea.InDayOfWeekHeader:
                        InDayOfWeekHeaderMouseUp(view);
                        break;

                    case eViewArea.InMonthHeader:
                        InMonthHeaderMouseUp(view);
                        break;

                    case eViewArea.InSideBarPanel:
                        InSideBarMouseUp(view);
                        break;

                    case eViewArea.InCondensedView:
                        InCondensedViewMouseUp();
                        break;
                }
            }
        }

        #region InContentMouseUp

        /// <summary>
        /// Handles BaseView InContent MouseUp events
        /// </summary>
        /// <param name="view">BaseView</param>
        /// <param name="e">MouseEventArgs</param>
        private void InContentMouseUp(BaseView view, MouseEventArgs e)
        {
            // Get the DateSelection start and end
            // from the current mouse location

            DateTime startDate, endDate;

            if (calendarView.GetDateSelectionFromPoint(
                e.Location, out startDate, out endDate) == true)
            {
                // If this date already falls outside the currently
                // selected range (DateSelectionStart and DateSelectionEnd)
                // then select the new range

                if (IsDateSelected(startDate, endDate) == false)
                {
                    calendarView.DateSelectionStart = startDate;
                    calendarView.DateSelectionEnd = endDate;
                }
            }

            // Remove any previously added view specific items

            for (int i = InContentContextMenu.SubItems.Count - 1; i > 0; i--)
                InContentContextMenu.SubItems.RemoveAt(i);

            // If this is a TimeLine view, then add a couple
            // of extra items

            if (view is TimeLineView)
            {
                ButtonItem bi = new ButtonItem();

                // Page Navigator

                bi.Text = (calendarView.TimeLineShowPageNavigation == true)
                    ? "Hide Page Navigator" : "Show Page Navigator";

                bi.BeginGroup = true;

                bi.Click += BiPageNavigatorClick;

                InContentContextMenu.SubItems.Add(bi);

                // Condensed Visibility

                if (calendarView.TimeLineCondensedViewVisibility ==
                    eCondensedViewVisibility.Hidden)
                {
                    bi = new ButtonItem("", "Show Condensed View");
                    bi.Click += BiCondensedClick;

                    InContentContextMenu.SubItems.Add(bi);
                }
            }

            ShowContextMenu(InContentContextMenu);
        }

        #region BiCondensedClick

        /// <summary>
        /// Handles InContentContextMenu Condensed selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BiCondensedClick(object sender, EventArgs e)
        {
            calendarView.TimeLineCondensedViewVisibility =
                eCondensedViewVisibility.AllResources;
        }

        #endregion

        #region BiPageNavigatorClick

        /// <summary>
        /// Handles InContentContextMenu PageNavigator selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BiPageNavigatorClick(object sender, EventArgs e)
        {
            calendarView.TimeLineShowPageNavigation =
                (calendarView.TimeLineShowPageNavigation == false);
        }

        #endregion

        #region IsDateSelected

        /// <summary>
        /// Determines if the given date range is within the currently selected
        /// CalendarView selection range (DateSelectionStart to DateSelectionEnd)
        /// </summary>
        /// <param name="startDate">Start date range</param>
        /// <param name="endDate">End date range</param>
        /// <returns>True if selected</returns>
        private bool IsDateSelected(DateTime startDate, DateTime endDate)
        {
            if (calendarView.DateSelectionStart.HasValue && calendarView.DateSelectionEnd.HasValue)
            {
                if (calendarView.DateSelectionStart.Value <= startDate &&
                    calendarView.DateSelectionEnd.Value >= endDate)
                    return (true);
            }

            return (false);
        }

        #endregion

        #region MiAddClick

        /// <summary>
        /// Handles BaseView "Add Appointment" 
        /// ContextMenu selections
        /// </summary>
        /// <param name="sender">MenuItem</param>
        /// <param name="e">EventArgs</param>
        void mnuAddAppointmentClick(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = calendarView.DateSelectionStart.GetValueOrDefault();
                DateTime endDate = calendarView.DateSelectionEnd.GetValueOrDefault();

                CreateAppointment(startDate, endDate);
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        #endregion

        #endregion

        #region InDayOfWeekHeaderMouseUp

        /// <summary>
        /// Handles BaseView InDayOfWeekHeader MouseUp events.
        /// </summary>
        /// <param name="view">BaseView</param>
        private void InDayOfWeekHeaderMouseUp(BaseView view)
        {
            if (view is MonthView)
            {
                MonthView mv = view as MonthView;

                // The View is a month view, so let the user
                // hide or show the SideBar panel

                if (mv.IsSideBarVisible == true)
                {
                    InHeaderHideSideBarContextItem.Visible = true;
                    InHeaderShowSideBarContextItem.Visible = false;
                }
                else
                {
                    InHeaderHideSideBarContextItem.Visible = false;
                    InHeaderShowSideBarContextItem.Visible = true;
                }
            }
            else
            {
                InHeaderHideSideBarContextItem.Visible = false;
                InHeaderShowSideBarContextItem.Visible = false;
            }

            InHeaderContextMenu.Tag = view;

            ShowContextMenu(InHeaderContextMenu);
        }

        #region MiCalendarColorClick

        /// <summary>
        /// Handles selection of a ContextMenu color item
        /// </summary>
        /// <param name="sender">MenuItem</param>
        /// <param name="e">EventArgs</param>
        void MiCalendarColorClick(object sender, EventArgs e)
        {
            ButtonItem mi = sender as ButtonItem;

            if (mi != null)
            {
                BaseView view = mi.Parent.Tag as BaseView;

                if (view != null)
                    view.CalendarColor = (eCalendarColor)Enum.Parse(typeof(eCalendarColor), mi.Text);
            }
        }

        #endregion

        #region SideBar show/hide

        /// <summary>
        /// Handles ContextMenu "Show" for the SideBar panel
        /// </summary>
        /// <param name="sender">MenuItem</param>
        /// <param name="e">EventArgs</param>
        void MiShowSideBarClick(object sender, EventArgs e)
        {
            ButtonItem bi = sender as ButtonItem;

            if (bi != null)
            {
                MonthView view = bi.Parent.Tag as MonthView;

                if (view != null)
                    view.IsSideBarVisible = true;
            }
        }

        /// <summary>
        /// Handles ContextMenu "Hide" for the SideBar panel
        /// </summary>
        /// <param name="sender">MenuItem</param>
        /// <param name="e">EventArgs</param>
        void MiHideSideBarClick(object sender, EventArgs e)
        {
            ButtonItem bi = sender as ButtonItem;

            if (bi != null)
            {
                MonthView view = bi.Parent.Tag as MonthView;

                if (view != null)
                    view.IsSideBarVisible = false;
            }
        }


        #endregion

        #endregion

        #region InMonthHeaderMouseUp

        /// <summary>
        /// Handles BaseView InMonthHeader MouseUp events.
        /// </summary>
        /// <param name="view">BaseView</param>
        private void InMonthHeaderMouseUp(BaseView view)
        {
            if (view is YearView)
            {
                // The View is a Year view, so let the user
                // hide or show the Gridlines

                InMonthHeaderHideGridLinesContextItem.Visible = calendarView.YearViewShowGridLines;
                InMonthHeaderShowGridLinesContextItem.Visible = !calendarView.YearViewShowGridLines;
            }

            InMonthHeaderContextMenu.Tag = view;

            ShowContextMenu(InMonthHeaderContextMenu);
        }

        #region Gridlines show/hide

        /// <summary>
        /// Handles ContextMenu "Show GridLines" for the Year View
        /// </summary>
        /// <param name="sender">MenuItem</param>
        /// <param name="e">EventArgs</param>
        void MiShowGridLinesClick(object sender, EventArgs e)
        {
            ButtonItem bi = sender as ButtonItem;

            if (bi != null)
            {
                YearView view = bi.Parent.Tag as YearView;

                if (view != null)
                    calendarView.YearViewShowGridLines = true;
            }
        }

        /// <summary>
        /// Handles ContextMenu "Hide GridLines" for the Year View
        /// </summary>
        /// <param name="sender">MenuItem</param>
        /// <param name="e">EventArgs</param>
        void MiHideGridLinesClick(object sender, EventArgs e)
        {
            ButtonItem bi = sender as ButtonItem;

            if (bi != null)
            {
                YearView view = bi.Parent.Tag as YearView;

                if (view != null)
                    calendarView.YearViewShowGridLines = false;
            }
        }

        #endregion

        #region miCycleHighlight_Click

        /// <summary>
        /// Handles ContextMenu "Cycle Highlight" for the Year View.  This
        /// routine cycles through all the possible Day Link Highlight values
        /// </summary>
        /// <param name="sender">MenuItem</param>
        /// <param name="e">EventArgs</param>
        void MiCycleHighlightClick(object sender, EventArgs e)
        {
            ButtonItem bi = sender as ButtonItem;

            if (bi != null)
            {
                YearView view = bi.Parent.Tag as YearView;

                if (view != null)
                {
                    if (calendarView.YearViewAppointmentLinkStyle == eYearViewLinkStyle.None)
                    {
                        if (_UserStyleSet == false)
                        {
                            _UserStyleSet = true;

                            calendarView.YearViewDrawDayBackground += YearViewDrawDayBackground;

                            calendarView.Refresh();
                        }
                        else
                        {
                            _UserStyleSet = false;

                            calendarView.YearViewDrawDayBackground -= YearViewDrawDayBackground;

                            NextLinkStyle();
                        }
                    }
                    else
                    {
                        NextLinkStyle();
                    }
                }
            }
        }

        #endregion

        #region NextLinkStyle

        /// <summary>
        /// Sets the next available Link style
        /// </summary>
        private void NextLinkStyle()
        {
            eYearViewLinkStyle linkStyle = calendarView.YearViewAppointmentLinkStyle;

            linkStyle++;

            if (linkStyle > eYearViewLinkStyle.Style5)
                linkStyle = eYearViewLinkStyle.None;

            calendarView.YearViewAppointmentLinkStyle = linkStyle;
        }

        #endregion

        #region YearViewDrawDayBackground

        /// <summary>
        /// Draws the YearView day background
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void YearViewDrawDayBackground(object sender, YearViewDrawDayBackgroundEventArgs e)
        {
            if ((e.YearMonth.DayIsSelected(e.Date.Day) == false) &&
                (e.YearMonth.DayHasAppointments(e.Date.Day) == true))
            {
                Color color;

                switch (e.Date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Friday:
                        color = Color.Yellow;
                        break;

                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Thursday:
                        color = Color.Coral;
                        break;

                    default:
                        color = Color.LightGreen;
                        break;
                }

                using (Brush br = new SolidBrush(color))
                    e.Graphics.FillRectangle(br, e.Bounds);

                e.Cancel = true;
            }
        }

        #endregion

        #endregion

        #region InSideBarMouseUp

        /// <summary>
        /// Handles SideBar MouseUp events
        /// </summary>
        /// <param name="view">BaseView</param>
        private void InSideBarMouseUp(BaseView view)
        {
            InSideBarContextMenu.Tag = view;

            ShowContextMenu(InSideBarContextMenu);
        }

        #endregion

        #region InCondensedViewMouseUp

        /// <summary>
        /// Handles Mouse Up events in the CondensedView
        /// area of the control
        /// </summary>
        private void InCondensedViewMouseUp()
        {
            ShowContextMenu(CondensedViewContextMenu);
        }

        #endregion

        #endregion

        #region AppointmentViewMouseUp

        /// <summary>
        /// Handles AppointmentView MouseUp events
        /// </summary>
        /// <param name="sender">AppointmentView</param>
        private void AppointmentViewMouseUp(object sender)
        {
            AppointmentView view = sender as AppointmentView;

            // Select the appointment

            if (view != null)
            {
                view.IsSelected = true;

                // Let the user delete the appointment

                mnuDeleteAppointment.Enabled = (view.Appointment.IsRecurringInstance == false);
                AppointmentContextMenu.Tag = view;
            }

            ShowContextMenu(AppointmentContextMenu);
        }

        #region miDelete_Click

        /// <summary>
        /// Handles BaseView "Delete Appointment" 
        /// ContextMenu selections
        /// </summary>
        /// <param name="sender">MenuItem</param>
        /// <param name="e">EventArgs</param>
        void mnuDeleteAppointmentClick(object sender, EventArgs e)
        {
            try
            {
                ButtonItem mi = sender as ButtonItem;

                if (mi != null)
                {
                    AppointmentView view = mi.Parent.Tag as AppointmentView;

                    if (view != null && view.Appointment != null)
                    {
                        Appointment appointment = view.Appointment;
                        AppointmentInfo appoinmentInfo = appointment.Tag as AppointmentInfo;
                        if (appoinmentInfo.Category != AppointmentInfo.UserCatgory)
                        {
                            MessageBoxHelper.ShowPrompt("不可以删除此日程。");
                            return;
                        }
                        if (MessageBoxHelper.ShowYesNo("确定删除吗?") == System.Windows.Forms.DialogResult.Yes)
                        {
                           
                            if (appoinmentInfo != null)
                            {
                                appointmentInfoCache.DeleteAppointmentInfo(appoinmentInfo);
                            }
                            calendarView.CalendarModel.Appointments.Remove(view.Appointment);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        #endregion

        #region Color item code

        void CategoryColor_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonItem bi = sender as ButtonItem;

                if (bi != null)
                {
                    AppointmentView view = bi.Parent.Tag as AppointmentView;

                    if (view != null)
                    {
                        view.Appointment.CategoryColor = bi.Tag as String;
                        UpdateAppointmentInfo(view.Appointment);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        #endregion

        #region Marker item code
        void TimeMarker_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonItem bi = sender as ButtonItem;

                if (bi != null)
                {
                    AppointmentView view = bi.Parent.Tag as AppointmentView;

                    if (view != null)
                    {
                        view.Appointment.TimeMarkedAs = ("Default").Equals(bi.Tag) ? null : bi.Tag as String;
                        UpdateAppointmentInfo(view.Appointment);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        #endregion

        #endregion

        #region AllDayPanelMouseUp

        /// <summary>
        /// Handles AllDayPanel MouseUp events
        /// </summary>
        /// <param name="sender">AllDayPanel</param>
        private void AllDayPanelMouseUp(object sender)
        {
            // Let the user Shrink and expand the panel
            // by 20 each time

            AllDayShrinkContextItem.Enabled = calendarView.FixedAllDayPanelHeight == -1 ||
                calendarView.FixedAllDayPanelHeight > 20;

            AllDayGrowContextItem.Enabled = calendarView.FixedAllDayPanelHeight < 200;
            AllDayReset.Enabled = calendarView.FixedAllDayPanelHeight != -1;
            AllDayPanelContextMenu.Tag = sender;

            ShowContextMenu(AllDayPanelContextMenu);
        }

        /// <summary>
        /// Handles "Shrink" ContextMenu selections
        /// </summary>
        /// <param name="sender">MenuItem</param>
        /// <param name="e">EventArgs</param>
        void MiShrinkClick(object sender, EventArgs e)
        {
            ButtonItem bi = sender as ButtonItem;

            if (bi != null)
            {
                AllDayPanel panel = bi.Parent.Tag as AllDayPanel;

                if (calendarView.FixedAllDayPanelHeight == -1)
                {
                    if (panel != null)
                        calendarView.FixedAllDayPanelHeight = panel.PanelHeight - 20;
                }
                else
                {
                    calendarView.FixedAllDayPanelHeight =
                        Math.Max(20, calendarView.FixedAllDayPanelHeight - 20);
                }
            }
        }

        /// <summary>
        /// Handles "Grow" ContextMenu selections
        /// </summary>
        /// <param name="sender">MenuItem</param>
        /// <param name="e">EventArgs</param>
        void MiGrowClick(object sender, EventArgs e)
        {
            ButtonItem bi = sender as ButtonItem;

            if (bi != null)
            {
                AllDayPanel panel = bi.Parent.Tag as AllDayPanel;

                if (calendarView.FixedAllDayPanelHeight == -1)
                {
                    if (panel != null)
                        calendarView.FixedAllDayPanelHeight = panel.PanelHeight + 20;
                }

                else
                {
                    calendarView.FixedAllDayPanelHeight =
                        Math.Min(500, calendarView.FixedAllDayPanelHeight + 20);
                }
            }
        }

        /// <summary>
        /// Handles "Reset" ContextMenu selections
        /// </summary>
        /// <param name="sender">MenuItem</param>
        /// <param name="e">EventArgs</param>
        void MiResetClick(object sender, EventArgs e)
        {
            calendarView.FixedAllDayPanelHeight = -1;
        }

        #endregion

        #region TimeRulerPanelMouseUp

        /// <summary>
        /// Handles TimeRulerPanel MouseUp events
        /// </summary>
        private void TimeRulerPanelMouseUp()
        {
            ShowContextMenu(TimeRulerPanelContextMenu);
        }

        /// <summary>
        /// Handles "TimeSlotDuration" ContextMenu selections
        /// </summary>
        /// <param name="sender">MenuItem</param>
        /// <param name="e">EventArgs</param>
        void MiTimeDurationClick(object sender, EventArgs e)
        {
            ButtonItem bi = sender as ButtonItem;

            if (bi != null)
            {
                int duration;

                if (int.TryParse(bi.Text, out duration) == true)
                    calendarView.TimeSlotDuration = duration;
            }
        }

        #endregion

        #region TimeLineHeaderPanelMouseUp

        /// <summary>
        /// Handles Mouse Up events in the TimeLineHeaderPanel.
        /// 
        /// (The TimeLineHeaderPanel is the area at the top of the
        /// TimeLineView that holds the Period and Interval Headers.)
        /// </summary>
        /// <param name="sender">TimeLineHeaderPanel</param>
        /// <param name="e">MouseEventArgs</param>
        private void TimeLineHeaderPanelMouseUp(object sender, MouseEventArgs e)
        {
            TimeLineHeaderPanel tp = sender as TimeLineHeaderPanel;

            if (tp != null)
            {
                eViewArea area = tp.GetViewAreaFromPoint(e.Location);

                if (area == eViewArea.InPeriodHeader)
                    InPeriodHeaderMouseUp();

                else if (area == eViewArea.InIntervalHeader)
                    InIntervalHeaderMouseUp();
            }
        }

        #region InPeriodHeaderMouseUp

        /// <summary>
        /// Handles MouseUp events in the Period Header
        /// </summary>
        private void InPeriodHeaderMouseUp()
        {
            ShowContextMenu(PeriodHeaderContextMenu);
        }

        #endregion

        #region InPeriodHeaderHide_Click

        /// <summary>
        /// Handles Period Header "Hide" menu selections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InPeriodHeaderHide_Click(object sender, EventArgs e)
        {
            calendarView.TimeLineShowPeriodHeader = false;
        }

        #endregion

        #region PeriodHeaderContextMenu Period change

        /// <summary>
        /// Handles PeriodHeaderContextMenu "Minute" selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPeriodMinutesCheckedChanged(object sender, EventArgs e)
        {
            if (btnPeriodMinutes.Checked == true)
                calendarView.TimeLinePeriod = eTimeLinePeriod.Minutes;
        }

        /// <summary>
        /// Handles PeriodHeaderContextMenu "Hours" selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPeriodHoursCheckedChanged(object sender, EventArgs e)
        {
            if (btnPeriodHours.Checked == true)
                calendarView.TimeLinePeriod = eTimeLinePeriod.Hours;
        }

        /// <summary>
        /// Handles PeriodHeaderContextMenu "Days" selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPeriodDaysCheckedChanged(object sender, EventArgs e)
        {
            if (btnPeriodDays.Checked == true)
                calendarView.TimeLinePeriod = eTimeLinePeriod.Days;
        }

        /// <summary>
        /// Handles PeriodHeaderContextMenu "Years" selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPeriodYearsCheckedChanged(object sender, EventArgs e)
        {
            if (btnPeriodYears.Checked == true)
                calendarView.TimeLinePeriod = eTimeLinePeriod.Years;
        }

        #endregion

        #region InIntervalHeaderMouseUp

        /// <summary>
        /// Handles MouseUp events in the IntervalHeader
        /// </summary>
        private void InIntervalHeaderMouseUp()
        {
            // Get rid of any previously added non-essential items

            for (int i = IntervalHeaderContextMenu.SubItems.Count - 1; i > 2; i--)
                IntervalHeaderContextMenu.SubItems.RemoveAt(i);

            // If the Period Header is not visible, present the user
            // with the items to be able to re-show it

            lblPeriodHeader2.Visible =
                (calendarView.TimeLineShowPeriodHeader == false);

            btnIntervalHeaderShow.Visible =
                (calendarView.TimeLineShowPeriodHeader == false);

            // Add some Interval time selection options
            // for the current selected Interval Period

            switch (calendarView.TimeLinePeriod)
            {
                case eTimeLinePeriod.Minutes:
                    AddIntervalMinutes();
                    break;

                case eTimeLinePeriod.Hours:
                    AddIntervalHours();
                    break;

                case eTimeLinePeriod.Days:
                    AddIntervalDays();
                    break;

                case eTimeLinePeriod.Years:
                    AddIntervalYears();
                    break;
            }

            ShowContextMenu(IntervalHeaderContextMenu);
        }

        #region Interval time support

        #region AddIntervalMinutes

        /// <summary>
        /// Adds Interval "Minute" items
        /// </summary>
        private void AddIntervalMinutes()
        {
            for (int i = 1; i <= 60; i++)
            {
                if (60 % i == 0)
                    AddIntervalItem(i);
            }
        }

        #endregion

        #region AddIntervalHours

        /// <summary>
        /// Adds Interval "Hour" items
        /// </summary>
        private void AddIntervalHours()
        {
            for (int i = 1; i <= 24; i++)
            {
                if (24 % i == 0)
                    AddIntervalItem(i);
            }
        }

        #endregion

        #region AddIntervalDays

        /// <summary>
        /// Adds Interval "Day" items
        /// </summary>
        private void AddIntervalDays()
        {
            for (int i = 1; i <= 10; i++)
                AddIntervalItem(i);

            for (int i = 30; i < 200; i += 30)
                AddIntervalItem(i);

            AddIntervalItem(365);
        }

        #endregion

        #region AddIntervalYears

        /// <summary>
        /// Adds Interval "Year" items
        /// </summary>
        private void AddIntervalYears()
        {
            for (int i = 1; i <= 10; i++)
                AddIntervalItem(i);
        }

        #endregion

        #region AddIntervalItem

        /// <summary>
        /// Adds individual Interval items
        /// </summary>
        /// <param name="i">Item to add</param>
        private void AddIntervalItem(int i)
        {
            ButtonItem bi = new ButtonItem("", i.ToString());

            bi.Click += BiIntervalClick;

            if (calendarView.TimeLineInterval == i)
                bi.Checked = true;

            IntervalHeaderContextMenu.SubItems.Add(bi);
        }

        #endregion

        #region bi_IntervalClick

        /// <summary>
        /// Handles Interval time selections
        /// </summary>
        /// <param name="sender">ButtonItem</param>
        /// <param name="e">EventArgs</param>
        private void BiIntervalClick(object sender, EventArgs e)
        {
            ButtonItem bi = sender as ButtonItem;

            if (bi != null)
            {
                int n;

                if (int.TryParse(bi.Text, out n) == true)
                    calendarView.TimeLineInterval = n;
            }
        }

        #endregion

        #endregion

        #region btnIntervalHeaderShow_Click

        /// <summary>
        /// Handles IntervalHeaderContextMenu "Show Header" selections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIntervalHeaderShowClick(object sender, EventArgs e)
        {
            calendarView.TimeLineShowPeriodHeader = true;
        }

        #endregion

        #endregion

        #endregion

        #region ShowContextMenu

        /// <summary>
        /// Shows the given ContextMenu
        /// </summary>
        /// <param name="cm">ContextMenu to show</param>
        private void ShowContextMenu(ButtonItem cm)
        {
            Point pt = MousePosition;
            cm.Popup(pt);
        }

        #endregion

        #endregion

        #region CalendarView1SelectedViewChanged

        /// <summary>
        /// Processes CalendarView SelectedViewChanged events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalendarView_SelectedViewChanged(object sender, SelectedViewEventArgs e)
        {
            switch (e.NewValue)
            {
                case eCalendarView.Day:
                    btnDay.Checked = true;
                    break;

                case eCalendarView.Week:
                    btnWeek.Checked = true;
                    break;

                case eCalendarView.Month:
                    btnMonth.Checked = true;
                    break;

                case eCalendarView.Year:
                    btnYear.Checked = true;
                    break;

                case eCalendarView.TimeLine:
                    btnTimeLine.Checked = true;
                    break;
            }
        }



        #endregion

        #region CondensedViewContextMenu support

        /// <summary>
        /// Handles "AllResources" selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCondensedViewAllClick(object sender, EventArgs e)
        {
            // AllResources - This selection enables Condensed
            // views to be displayed in every visible TimeLine
            // when Multiuser TimeLine views are displayed

            calendarView.TimeLineCondensedViewVisibility
                = eCondensedViewVisibility.AllResources;
        }

        /// <summary>
        /// Handles "SelectedResource" selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCondensedViewSelectedClick(object sender, EventArgs e)
        {
            // SelectedResource - This selection enables Condensed
            // views to be displayed only in the currently selected
            // TimeLine view when Multiuser TimeLine views are displayed

            calendarView.TimeLineCondensedViewVisibility
                = eCondensedViewVisibility.SelectedResource;
        }

        /// <summary>
        /// Handles "Hidden" selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCondensedViewHiddenClick(object sender, EventArgs e)
        {
            // Hidden - This selection disables all Condensed
            // views from being displayed

            calendarView.TimeLineCondensedViewVisibility
                = eCondensedViewVisibility.Hidden;
        }

        #endregion


        #region BtnTodayClick

        /// <summary>
        /// Sets the calendar view display to today's date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTodayClick(object sender, EventArgs e)
        {
            calendarView.ShowDate(DateTime.Today);
        }

        #endregion

        #region BtnNewAppointmentClick

        /// <summary>
        /// Adds a new appointment to the calendar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewAppointmentClick(object sender, EventArgs e)
        {
            try
            {
                // Create new appointment and add it to the model
                // Appointment will show up in the view automatically
                DateTime? startDate = DateTime.Now;
                DateTime? endDate = null;

                if (calendarView.DateSelectionStart.HasValue &&
                    calendarView.DateSelectionEnd.HasValue)
                {
                    startDate = calendarView.DateSelectionStart;
                    endDate = calendarView.DateSelectionEnd;
                }
                CreateAppointment(startDate, endDate);
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }

        }

        private void CreateAppointment(DateTime? startTime, DateTime? endTime)
        {
            AppointmentInfo appointmentInfo = new AppointmentInfo();

            appointmentInfo.StartTime = startTime;
            appointmentInfo.EndTime = endTime;
            appointmentInfo.Owner = UserManager.UserProfile.UserId;
            appointmentInfo.Category = AppointmentInfo.UserCatgory;
            AppointmentForm form = new AppointmentForm();
            form.FormMode = SimpleCrm.FormMode.Add;
            form.Appointment = appointmentInfo;
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                appointmentInfoCache.SaveAppointmentInfo(appointmentInfo);
                Appointment ap = AddAppointment(appointmentInfo);

                calendarView.EnsureVisible(ap);
            }
        }

        private void EditAppointment(Appointment appointment)
        {
            AppointmentInfo appointmentInfo = appointment.Tag as AppointmentInfo;
            if (appointmentInfo != null)
            {

                AppointmentForm form = new AppointmentForm();
                form.FormMode = appointmentInfo.Category == AppointmentInfo.UserCatgory ? FormMode.Edit : FormMode.View;
                form.Appointment = appointmentInfo;
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    appointmentInfoCache.SaveAppointmentInfo(appointmentInfo);
                    Appointment ap = UpdateAppointment(appointment, appointmentInfo);

                    calendarView.EnsureVisible(ap);
                }
            }
        }

        private Appointment AddAppointment(AppointmentInfo appointmentInfo)
        {
            Appointment appointment = new Appointment();

            appointment.StartTime = appointmentInfo.StartTime.Value;
            appointment.EndTime = appointmentInfo.EndTime.Value;
            appointment.Subject = appointmentInfo.Subject;
            appointment.Description = appointmentInfo.Content;
            appointment.Id = (int)appointmentInfo.AppointmentInfoId.Value;
            appointment.Tag = appointmentInfo;

            appointment.CategoryColor = appointmentInfo.CategoryColor;

            appointment.TimeMarkedAs = appointmentInfo.TimerMarker;

            // Add appointment to the model

            calendarView.CalendarModel.Appointments.Add(appointment);

            return (appointment);
        }

        private Appointment UpdateAppointment(Appointment appointment, AppointmentInfo appointmentInfo)
        {
            appointment.StartTime = appointmentInfo.StartTime.Value;
            appointment.EndTime = appointmentInfo.EndTime.Value;
            appointment.Subject = appointmentInfo.Subject;
            appointment.Description = appointmentInfo.Content;
            appointment.Id = (int)appointmentInfo.AppointmentInfoId.Value;
            appointment.Tag = appointmentInfo;

            return (appointment);
        }
        #endregion

        private void ScheduleMainForm_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today.Date;
            appointmentInfoCache.GetAppointmentOf12Month(today, ai => AddAppointment(ai) );
            //calendarView.ShowOnlyWorkDayHours
        }

        private void calendarView_AppointmentViewChanged(object sender, AppointmentViewChangedEventArgs e)
        {
            try
            {
                AppointmentView av = e.CalendarItem as AppointmentView;
                if (av != null)
                {
                    UpdateAppointmentInfo(av.Appointment);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private void UpdateAppointmentInfo(Appointment appointment)
        {
            AppointmentInfo appoInfo = appointment.Tag as AppointmentInfo;
            if (appoInfo != null)
            {
                appoInfo.StartTime = appointment.StartTime;
                appoInfo.EndTime = appointment.EndTime;
                appoInfo.CategoryColor = appointment.CategoryColor;
                appoInfo.TimerMarker = appointment.TimeMarkedAs;

                appointmentInfoCache.SaveAppointmentInfo(appoInfo);
            }
        }

        private void dateNavigator_DateChanged(object sender, DateNavigator.DateChangedEventArgs e)
        {
            GetAppointmentInfo(e.NewStartDate,e.NewEndDate);
        }

        private void GetAppointmentInfo(DateTime dateTime)
        {
            appointmentInfoCache.GetAppointmentListByMonth(dateTime, ai => AddAppointment(ai));
        }

        private void GetAppointmentInfo(DateTime startDate, DateTime endDate)
        {
            appointmentInfoCache.GetAppointmentListByMonth(startDate,endDate, ai => AddAppointment(ai));
        }
    }
}