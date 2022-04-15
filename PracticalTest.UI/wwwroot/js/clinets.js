var clientResponsePhone = {};
$.ajax({
    type: "GET",
    dataType: "json",
    url: "/Client/GetAll",
    success: function (result) {
        var sel = $("#clientsSelect");
        for (var i = 0; i < result.length; i++) {
            sel.append('<option value="' + result[i].id + '">' + result[i].clientUniqueId + ' | ' + result[i].name + ' ' + result[i].surname + '</option>');
            clientResponsePhone[result[i].id] = result[i].telephoneNr
        }
    }
});

$('#clientsSelect').change(function (e) {
    var optionSelected = $("option:selected", this);
    var valueSelected = this.value;
    $("#clientPhone").val(clientResponsePhone[valueSelected]);
});

var calculateInvoices = function (loanData) {
    $.ajax({
        type: "Post",
        data: loanData,
        dataType: "json",
        url: "/Invoice/GetInvoices",
        success: function (result) {
            var div = $("#table");
            div.empty();
            var allPayAmount = 0;
            var html =
                '<table class="table"> <thead class= "thead-dark"> <tr> <th scope="col">#</th> <th scope="col">Invoice No</th> <th scope="col">Due Date</th> <th scope="col">Amount</th></tr></thead ><tbody>';
            for (var i = 0; i < result.length; i++) {
                allPayAmount += result[i].amount;
                html += '<tr> <td>' +
                    (i + 1) +
                    '</td > <td>' +
                    result[i].invoiceNo +
                    '</td> <td>' +
                    dateFormat(result[i].dueDate, 'dd/MM/yyyy') +
                    '</td> <td>' + result[i].amount.toFixed(2) + '</td></tr >';
            }
            html += "</tbody> </table >";
            var totalInterestInput = $("#totalInterest");
            totalInterestInput.val((allPayAmount - $("#loanAmount").val()).toFixed(4));
            $('#issueLoan').prop('disabled', false);
            var totalInterestBase = $("#totalInterestBase");
            totalInterestBase[0].classList.remove("d-none");
            $("#error").empty();
            div.append(html);
        },
        error: function (jsx, status, errorMessage) {
            $("#error").empty();
            $("#error").append('<h4 class ="text-danger">Error</h4>');
        }
    });
}

function dateFormat(inputDate, format) {
    //parse the input date
    var date = new Date(inputDate);

    //extract the parts of the date
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();

    //replace the month
    format = format.replace("MM", month.toString().padStart(2, "0"));

    //replace the year
    if (format.indexOf("yyyy") > -1) {
        format = format.replace("yyyy", year.toString());
    } else if (format.indexOf("yy") > -1) {
        format = format.replace("yy", year.toString().substr(2, 2));
    }

    //replace the day
    format = format.replace("dd", day.toString().padStart(2, "0"));

    return format;
}

var createObj = function () {
    var obj = {
        amount: $("#loanAmount").val(),
        loanPeriod: $("#loanPeriod").val(),
        interestRate: $("#interestRate").val(),
        payoutDate: $("#payoutDate").val()
    }
    calculateInvoices(obj);
}