import { Input, Button, InputRightAddon, InputGroup } from "@chakra-ui/react";
import { CalendarIcon } from "@chakra-ui/icons";
import { forwardRef } from "react";
import PropTypes from "prop-types";

export const localDate = (dt?:Date)=>{
  if(dt)
  return new Date(dt.valueOf() + dt.getTimezoneOffset() * 60 * 1000);
  return dt;
}

export const DateInputGroup = forwardRef(
  (
    //@ts-ignore
    { value, onClick, disabled, readOnly, onChange, ...props },
    ref
  ) => {
    return(
    <InputGroup size={"sm"}>
      <Input
        value={value}
        isReadOnly={readOnly}  
        size={"sm"}
        fontSize={"sm"}
        backgroundColor={readOnly ? "gray.100" : "white"}
        onChange={onChange}
      />
      <InputRightAddon
        onClick={onClick}
        as={Button} 
        isDisabled={disabled || readOnly}
      >
        <CalendarIcon />
      </InputRightAddon>
    </InputGroup>
  )}
);

const propTypes = {
  adjustDateOnChange: PropTypes.bool,
  allowSameDay: PropTypes.bool,
  ariaDescribedBy: PropTypes.string,
  ariaInvalid: PropTypes.string,
  ariaLabelClose: PropTypes.string,
  ariaLabelledBy: PropTypes.string,
  ariaRequired: PropTypes.string,
  autoComplete: PropTypes.string,
  autoFocus: PropTypes.bool,
  calendarClassName: PropTypes.string,
  calendarContainer: PropTypes.func,
  children: PropTypes.node,
  chooseDayAriaLabelPrefix: PropTypes.string,
  closeOnScroll: PropTypes.oneOfType([PropTypes.bool, PropTypes.func]),
  className: PropTypes.string,
  customInput: PropTypes.element,
  customInputRef: PropTypes.string,
  calendarStartDay: PropTypes.number,
  // eslint-disable-next-line react/no-unused-prop-types
  dateFormat: PropTypes.oneOfType([PropTypes.string, PropTypes.array]),
  dateFormatCalendar: PropTypes.string,
  dayClassName: PropTypes.func,
  weekDayClassName: PropTypes.func,
  disabledDayAriaLabelPrefix: PropTypes.string,
  monthClassName: PropTypes.func,
  timeClassName: PropTypes.func,
  disabled: PropTypes.bool,
  disabledKeyboardNavigation: PropTypes.bool,
  dropdownMode: PropTypes.oneOf(["scroll", "select"]).isRequired,
  endDate: PropTypes.instanceOf(Date),
  excludeDates: PropTypes.array,
  excludeDateIntervals: PropTypes.arrayOf(
    PropTypes.shape({
      start: PropTypes.instanceOf(Date),
      end: PropTypes.instanceOf(Date)
    })
  ),
  filterDate: PropTypes.func,
  fixedHeight: PropTypes.bool,
  formatWeekNumber: PropTypes.func,
  highlightDates: PropTypes.array,
  id: PropTypes.string,
  includeDates: PropTypes.array,
  includeDateIntervals: PropTypes.array,
  includeTimes: PropTypes.array,
  injectTimes: PropTypes.array,
  inline: PropTypes.bool,
  isClearable: PropTypes.bool,
  locale: PropTypes.oneOfType([
    PropTypes.string,
    PropTypes.shape({ locale: PropTypes.object })
  ]),
  maxDate: PropTypes.instanceOf(Date),
  minDate: PropTypes.instanceOf(Date),
  monthsShown: PropTypes.number,
  name: PropTypes.string,
  onBlur: PropTypes.func,
  onChange: PropTypes.func.isRequired,
  onSelect: PropTypes.func,
  onWeekSelect: PropTypes.func,
  onClickOutside: PropTypes.func,
  onChangeRaw: PropTypes.func,
  onFocus: PropTypes.func,
  onInputClick: PropTypes.func,
  onKeyDown: PropTypes.func,
  onMonthChange: PropTypes.func,
  onYearChange: PropTypes.func,
  onInputError: PropTypes.func,
  open: PropTypes.bool,
  onCalendarOpen: PropTypes.func,
  onCalendarClose: PropTypes.func,
  openToDate: PropTypes.instanceOf(Date),
  peekNextMonth: PropTypes.bool,
  placeholderText: PropTypes.string,
  popperContainer: PropTypes.func,
  popperClassName: PropTypes.string, // <PopperComponent/> props
  popperModifiers: PropTypes.arrayOf(PropTypes.object), // <PopperComponent/> props
  //popperPlacement: PropTypes.oneOf(popperPlacementPositions), // <PopperComponent/> props
  popperProps: PropTypes.object,
  preventOpenOnFocus: PropTypes.bool,
  readOnly: PropTypes.bool,
  required: PropTypes.bool,
  scrollableYearDropdown: PropTypes.bool,
  scrollableMonthYearDropdown: PropTypes.bool,
  selected: PropTypes.instanceOf(Date),
  selectsEnd: PropTypes.bool,
  selectsStart: PropTypes.bool,
  selectsRange: PropTypes.bool,
  selectsDisabledDaysInRange: PropTypes.bool,
  showMonthDropdown: PropTypes.bool,
  showPreviousMonths: PropTypes.bool,
  showMonthYearDropdown: PropTypes.bool,
  showWeekNumbers: PropTypes.bool,
  showYearDropdown: PropTypes.bool,
  strictParsing: PropTypes.bool,
  forceShowMonthNavigation: PropTypes.bool,
  showDisabledMonthNavigation: PropTypes.bool,
  startDate: PropTypes.instanceOf(Date),
  startOpen: PropTypes.bool,
  tabIndex: PropTypes.number,
  timeCaption: PropTypes.string,
  title: PropTypes.string,
  todayButton: PropTypes.node,
  useWeekdaysShort: PropTypes.bool,
  formatWeekDay: PropTypes.func,
  value: PropTypes.string,
  weekLabel: PropTypes.string,
  withPortal: PropTypes.bool,
  portalId: PropTypes.string,
  portalHost: PropTypes.instanceOf(ShadowRoot),
  yearItemNumber: PropTypes.number,
  yearDropdownItemNumber: PropTypes.number,
  shouldCloseOnSelect: PropTypes.bool,
  showTimeInput: PropTypes.bool,
  showMonthYearPicker: PropTypes.bool,
  showFullMonthYearPicker: PropTypes.bool,
  showTwoColumnMonthYearPicker: PropTypes.bool,
  showFourColumnMonthYearPicker: PropTypes.bool,
  showYearPicker: PropTypes.bool,
  showQuarterYearPicker: PropTypes.bool,
  showTimeSelect: PropTypes.bool,
  showTimeSelectOnly: PropTypes.bool,
  timeFormat: PropTypes.string,
  timeIntervals: PropTypes.number,
  minTime: PropTypes.instanceOf(Date),
  maxTime: PropTypes.instanceOf(Date),
  excludeTimes: PropTypes.array,
  filterTime: PropTypes.func,
  useShortMonthInDropdown: PropTypes.bool,
  clearButtonTitle: PropTypes.string,
  clearButtonClassName: PropTypes.string,
  previousMonthAriaLabel: PropTypes.string,
  previousMonthButtonLabel: PropTypes.oneOfType([
    PropTypes.string,
    PropTypes.node
  ]),
  nextMonthAriaLabel: PropTypes.string,
  nextMonthButtonLabel: PropTypes.oneOfType([PropTypes.string, PropTypes.node]),
  previousYearAriaLabel: PropTypes.string,
  previousYearButtonLabel: PropTypes.string,
  nextYearAriaLabel: PropTypes.string,
  nextYearButtonLabel: PropTypes.string,
  timeInputLabel: PropTypes.string,
  renderCustomHeader: PropTypes.func,
  renderDayContents: PropTypes.func,
  wrapperClassName: PropTypes.string,
  focusSelectedMonth: PropTypes.bool,
  onDayMouseEnter: PropTypes.func,
  onMonthMouseLeave: PropTypes.func,
  showPopperArrow: PropTypes.bool,
  excludeScrollbar: PropTypes.bool,
  enableTabLoop: PropTypes.bool,
  customTimeInput: PropTypes.element,
  weekAriaLabelPrefix: PropTypes.string
};
