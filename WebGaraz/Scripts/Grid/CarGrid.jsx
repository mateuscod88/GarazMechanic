import '@devexpress/dx-react-grid-bootstrap4/dist/dx-react-grid-bootstrap4.css';
import { Grid, Table, TableHeaderRow } from '@devexpress/dx-react-grid-material-ui';
import { Column } from '@devexpress/dx-react-grid';
class CarGrid extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            columns :
            [
                { name: 'model', title: 'Model' },
                { name: 'brand', title: 'Marka' },
                { name: 'engine', title: 'Silnik' },
                { name: 'regNum', title: 'Nr Rejestracyjny' },
                { name: 'phone', title: 'Telefon' },
                { name: 'dueDateTechService', title: 'Do Przeglądu' },
                { name: 'lastOilChange', title: 'Wymiana Oleju' }
            ],
            rows:
            [
                { model: "A4", brand: "Audi", engine: "1.9Tdi", regNum: "BIA8704", phone: "513524045", dueDateTechService: "10.04.2019", lastOilChange: "200tys" },
                { model: "A4", brand: "Audi", engine: "1.9Tdi", regNum: "BIA8704", phone: "513524045", dueDateTechService: "10.04.2019", lastOilChange: "200tys" },
                { model: "A4", brand: "Audi", engine: "1.9Tdi", regNum: "BIA8704", phone: "513524045", dueDateTechService: "10.04.2019", lastOilChange: "200tys" },
            ]

        }
    }
    render() {
        const { columns, rows } = this.state;
        return (
            <div class="mateo">
                <Grid
                    rows={rows}
                    columns={columns}>
                    <Table />
                    <TableHeaderRow />
                </Grid>
            </div>
        );
    }
}

ReactDOM.render(
    <CarGrid />,
    document.getElementById('car-grid')
)