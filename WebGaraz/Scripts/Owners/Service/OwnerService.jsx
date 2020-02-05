class OwnerService {
    constructor() {
        this.repairs = null;
        this.columns = null;
        this.singleRow = null;
        this.isRowSelected = false;
        this.isRepairDetailsDialogBox = false;
        this.updateGrid = false;
    }
    async AddRepair(repairDTO) {
        const postResult = await fetch('/repairs/addRepair', {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'POST',
            body: JSON.stringify(repairDTO)
        });
        await postResult;
    }
    async UpdateRepair(repairDTO) {
        const putResult = await fetch('home/updateRepair?id=' + this.state.row.id, {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'PUT',
            body: JSON.stringify(repairDTO)

        });
        await putResult;
    }
    async GetAll() {
        const result = await fetch('/owners/GetOwners')
            .then(response => response.json())
            .then(data => this.repairs = {
                rows: (data.map(suggestion => ({
                    id: suggestion.Id,
                    name: suggestion.Name,
                    date: suggestion.Date,
                    note: suggestion.Note,
                    carBrand: suggestion.Brand,
                    carModel: suggestion.Model,
                    carRegNum: suggestion.PlateNumber,

                }))),
            });
        await result;
        debugger;
        return this.repairs.rows;
    }
    GetColumns() {
        this.columns =
            [
                { name: 'carBrand', title: "Marka" },
                { name: 'carModel', title: "Model" },
                { name: 'carRegNum', title: "Numer Rejestracyjny" },
                { name: 'name', title: "Nazwa" },
                { name: 'date', title: "Data Naprawy" },
            ];
        return this.columns;
    }
    SetSingleRow(singleRow) {
        this.singleRow = singleRow;
    }
    GetSingleRow() {
        return this.singleRow;
    }
    SetIsRowSelected(isRowSelected) {
        this.isRowSelected = isRowSelected;
    }
    SetRepairDetailsDialogBox(isOpen) {
        this.isRepairDetailsDialogBox = isOpen;
    }
    GetRepairDetailsDialogBox() {
        return this.isRepairDetailsDialogBox;
    }
    GetUpdateGrid() {
        return this.updateGrid;
    }
    SetUpdateGrid(updateGrid) {
        this.updateGrid = updateGrid;
    }
}
export default OwnerService;