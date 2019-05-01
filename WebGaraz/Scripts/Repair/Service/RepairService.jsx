class RepairService {
    constructor() {
        this.repairs = null;
        this.columns = null;
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
    async GetAll() {
        const result = await fetch('/repairs/GetRepairs')
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
}
export default RepairService;