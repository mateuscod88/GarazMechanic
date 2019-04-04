import React, { Component } from 'react';
import '@devexpress/dx-react-grid-bootstrap4/dist/dx-react-grid-bootstrap4.css';
import { EditingState } from '@devexpress/dx-react-grid';
import { Grid, Table, TableHeaderRow, TableEditColumn } from '@devexpress/dx-react-grid-material-ui';


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
            rows:
                [
                    { id: 1, model: "A4", brand: "Audi", engine: "1.9Tdi", regNum: "BIA8704", phone: "513524045", dueDateTechService: "10.04.2019", lastOilChange: "200tys" },
                    { id: 2, model: "A4", brand: "Audi", engine: "1.9Tdi", regNum: "BIA8704", phone: "513524045", dueDateTechService: "10.04.2019", lastOilChange: "200tys" },
                    { id: 3, model: "A4", brand: "Audi", engine: "1.9Tdi", regNum: "BIA8704", phone: "513524045", dueDateTechService: "10.04.2019", lastOilChange: "200tys" },
                ]

        };
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
                    <EditingState
                        onCommitChanges={this.commitChanges}
                    />
                    <Table />
                    <TableHeaderRow />
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
