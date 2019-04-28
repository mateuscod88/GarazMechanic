import React, { Component } from 'react';
import { EditingState, PagingState, IntegratedPaging, SelectionState } from '@devexpress/dx-react-grid';
import { Grid, Table, TableHeaderRow, TableEditColumn, PagingPanel, TableSelection } from '@devexpress/dx-react-grid-material-ui';

const getRowId = row => row.id;

class CarGrid extends Component {
    constructor(props) {
        super(props);
        this.state = {
            columns:
                [
                    { name: 'model', title: 'Model' },
                    { name: 'brand', title: 'Marka' },
                    { name: 'engine', title: 'Silnik' },
                    { name: 'regNum', title: 'Nr Rejestracyjny' },
                    { name: 'phone', title: 'Telefon' },
                    { name: 'dueDateTechService', title: 'Następny Przegląd' },
                    { name: 'lastOilChange', title: 'Wymiana Oleju' }
                ],
            rows: [],
            selectedRows:0,
            selection:[],

        };
    }
    componentDidMount() {
         fetch('/home/AllCarsRegistered')
            .then(response => response.json())
            .then(data => this.setState({
                rows: (data.map(suggestion => ({
                    id: suggestion.Id,
                    model: suggestion.Model,
                    modelId: suggestion.ModelId,
                    brand: suggestion.Brand,
                    brandId: suggestion.BrandId,
                    engine: suggestion.Engine,
                    engineId: suggestion.EngineId,
                    regNum: suggestion.PlateNumber,
                    phone: suggestion.Phone,
                    counter: suggestion.KilometerCounter,
                    dueDateTechService: suggestion.TechnicalCheck,
                    lastOilChange: suggestion.LatestOilChange,
                    owner: { id: suggestion.OwnerId, name: suggestion.OwnerName },
                    phone: suggestion.Phone,
                    year: suggestion.Year,
                }))),
            }));
    }
    componentDidUpdate(prevProps) {
        if (this.props.update == true) {
            fetch('/home/AllCarsRegistered')
                .then(response => response.json())
                .then(data => this.setState({
                    rows: (data.map(suggestion => ({
                        id: suggestion.Id,
                        model: suggestion.Model,
                        modelId: suggestion.ModelId,
                        brand: suggestion.Brand,
                        brandId: suggestion.BrandId,
                        engine: suggestion.Engine,
                        engineId: suggestion.EngineId,
                        regNum: suggestion.PlateNumber,
                        phone: suggestion.Phone,
                        counter: suggestion.KilometerCounter,
                        dueDateTechService: suggestion.TechnicalCheck,
                        lastOilChange: suggestion.LatestOilChange,
                        owner: { id: suggestion.OwnerId, name: suggestion.OwnerName },
                        phone: suggestion.Phone,
                        year: suggestion.Year,
                    }))),
                }));
        }
    }
    commitChanges({ added, changed, deleted }) {
        let { rows } = this.state;
        if (added) {

        }
        if (changed) {

        }
        if (deleted) {

        }
    }
    changeSelection = selection => {
        var sel = [];
        sel[0] = selection[selection.length - 1];
        var rowId = sel[0];
        debugger;
        var row = this.state.rows[this.state.rows.findIndex(row => row.id == rowId)];
        var dialogBtn = this.props.selectChange;
        if (selection.length != 0) {
            dialogBtn.setState({
                row: row,
                isRowSelected: false,
            });
        }
        else {
            dialogBtn.setState({
                isRowSelected: true,
            });
        }
        debugger;
        
        this.setState({ selection: sel, selectedRows: sel[0], });
    }
    toggleSelectionRow = (rowIds, state) => {
        debugger;
        var st = rowIds;

    }
    render() {

        const { columns, rows, selection } = this.state;
        return (
            <div class="car-grid-de">
                <Grid
                    rows={rows}
                    columns={columns}
                    getRowId={getRowId}>

                    <SelectionState
                        selection={selection}
                        onSelectionChange={this.changeSelection}
                    />
                    <PagingState
                        defaultCurrentPage={0}
                        pageSize={5}
                    />
                    <IntegratedPaging />
                    <EditingState
                        onCommitChanges={this.commitChanges}
                    />
                    <Table />
                    <TableHeaderRow />
                    <PagingPanel />
                    <TableEditColumn
                        showAddCommand
                        showEditCommand
                        showDeleteCommand
                    />
                    <TableSelection
                        selectByRowClick
                        highlightRow
                        showSelectionColumn={false}
                    />
                </Grid>
            </div>
        );
    }
}

export default CarGrid;
