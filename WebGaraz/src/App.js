import React, { Component } from 'react';
import '@devexpress/dx-react-grid-bootstrap4/dist/dx-react-grid-bootstrap4.css';
import { EditingState,PagingState,IntegratedPaging } from '@devexpress/dx-react-grid';
import { Grid, Table, TableHeaderRow, TableEditColumn,PagingPanel } from '@devexpress/dx-react-grid-material-ui';
import { debug } from 'util';


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

        };
    }
    componentDidMount() {
         fetch('/home/AllCarsRegistered')
            .then(response => response.json())
            .then(data => this.setState({
                rows: (data.map(suggestion => ({
                    id: suggestion.Id,
                    model: suggestion.Model,
                    brand: suggestion.Brand,
                    engine: suggestion.Engine,
                    regNum: suggestion.PlateNumber,
                    phone: suggestion.Phone,
                    dueDateTechService: suggestion.TechnicalCheck,
                    lastOilChange: suggestion.LatestOilChange
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
                        brand: suggestion.Brand,
                        engine: suggestion.Engine,
                        regNum: suggestion.PlateNumber,
                        phone: suggestion.Phone,
                        dueDateTechService: suggestion.TechnicalCheck,
                        lastOilChange: suggestion.LatestOilChange
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
    render() {
        
        const { columns, rows } = this.state;
        return (
            <div class="car-grid-de">
                <Grid
                    rows={rows}
                    columns={columns}>
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
                </Grid>
            </div>
        );
    }
}

export default CarGrid;
