import * as React from "react";
import JqxGrid, {
  IGridProps,
  jqx
} from "jqwidgets-scripts/jqwidgets-react-tsx/jqxgrid";

import { userService } from "../../services/userService";
import { format, isValid } from "date-fns";
import _ from "lodash";
import { handoverService } from "src/services/handoverService";
import { getPatientService } from "src/services/getPatientService";
import { handovergroupService } from "src/services/handoverGroupService";
class HandoverGrid extends React.PureComponent<{}, IGridProps | any> {
  private myGrid = React.createRef<JqxGrid>();

  constructor(props: {}) {
    super(props);
    this.onFetch = this.onFetch.bind(this);
    this.onSelect = this.onSelect.bind(this);
    this.onBinding = this.onBinding.bind(this);
    this.getSelected = this.getSelected.bind(this);
    this.clearSelection = this.clearSelection.bind(this);
    this.refresh = _.debounce(this.refresh.bind(this), 300);
    this.clear = this.clear.bind(this);
    this.state = {
      isDrawer: false,
      selectedRow: null,
      rowsheight: 30,
      columns: [
        {
          text: "logDate",
          datafield: "updateDate",
          cellsformat: "yyyy-MM-dd HH:mm",
          width: "120px",
          sortable: false,
          filterable: false
        },
        {
          text: "groupName",
          datafield: "groupName",
          width: "200px",
          sortable: false,
          filterable: false
        },
        { text: "patientName", datafield: "patientName" },
        {
          text: "specialtyCode",
          datafield: "specialtyCode",
          width: "120px"
        },
        { text: "wardCode", datafield: "wardCode", width: "120px" },
        { text: "bedNumber", datafield: "bedNumber", width: "120px" },
        {
          text: "admissionTime",
          datafield: "admissionTime",
          cellsformat: "yyyy-MM-dd",
          width: "200px"
        },
        { text: "caseNumber", datafield: "caseNumber", width: "200px" }
      ],
      source: new jqx.dataAdapter({
        datafields: [
          //{ name: "id", type: "string" },
          { name: "updateDate", type: "date", format: "yyyy-MM-ddTHH:mm:ssZ" },
          { name: "dob", type: "date", format: "yyyy-MM-dd"  },
          { name: "sex", type: "string" },
          { name: "patientKey", type: "string" },
          { name: "patientName", type: "string" },
          { name: "groupId", type: "string" },
          { name: "groupName", type: "string" },
          { name: "wardCode", type: "string" },
          { name: "specialtyCode", type: "string" },
          { name: "bedNumber", type: "string" },
          { name: "admissionTime", type: "date", format: "yyyy-MM-ddTHH:mm:ssZ"  },
          { name: "caseNumber", type: "string" }
        ],
        totalrecords: 0,
        datatype: "json",
        id: "patientKey",
        root: "rows",
        sortcolumn: "bedNumber",
        sortdirection: "asc",
        url: `${process.env.REACT_APP_API}/api/Handover/QueryHandover`,
        loadError(jqXHR: any, status: any, error: any) {

        },
        beforeSend: function (jqXHR: any, settings: any) {
          let token = userService.userValue?.token;
          jqXHR.setRequestHeader("Authorization", "Bearer " + token);
        },
        beforeprocessing: function (data: any) {
          this.totalrecords = data.totalRows;
        },

        processdata: function (data: any) {
          data.specialtyCode = handovergroupService.groupValue.specialtyCode;
          if (isValid(handoverService?.dateValue)) {
            data.asof = format(handoverService?.dateValue, "yyyy-MM-dd");
          }
        }
      })
    };
  }

  public render() {
    return (
      <>
        <JqxGrid
          theme={"material-green"}
          ref={this.myGrid}
          onFilter={this.onFetch}
          // onPagechanged={this.onFetch}
          // onPagesizechanged={this.onFetch}
          onSort={this.onFetch}
          onCellclick={this.onSelect}
          rendergridrows={this.onRender}
          onBindingcomplete={this.onBinding}
          source={this.state.source}
          columns={this.state.columns}
          pageable={true}
          pagesize={5}
          altrows={true}
          sortable={true}
          columnsresize={true}
          filterable={true}
          virtualmode={true}
          autoheight={true}
          selectionmode={"singlerow"}
          autoshowfiltericon={false}
          updatedelay={20}
          rowsheight={this.state.rowsheight}
          width={"100%"}
          scrollmode={"deferred"}
        />
      </>
    );
  }

  private onBinding(e: any) {
    this.myGrid.current!.setOptions({ rowsheight: this.state.rowsheight });
  }

  private onRender(obj: any) {
    return obj.data;
  }
  private getSelected() {
    const selected = this.myGrid.current!.getselectedrowindex();
    return selected;
  }

  private onFetch(e: any): void {
    this.refresh();
    this.myGrid.current!.setOptions({ rowsheight: this.state.rowsheight });
  }

  private onSelect(e: any) {
    getPatientService.send(
      this.myGrid.current?.getrowdatabyid(e?.args?.row?.bounddata.patientKey)
    );
  }
  public refresh() {
    this.myGrid.current?.updatebounddata();
  }
  public clearSelection() {
    this.myGrid.current!.clearselection();
  }
  public clear() {
    this.myGrid.current?.clear();
  }
}

export { HandoverGrid };
