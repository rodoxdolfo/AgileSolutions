var mainChart;

$(document).ready(function () {

    var ctx = $('#barChart');
    $('#spanFilters').text("Sales by Month:" + $("#categoryDropdown").val() + ", " + $("#productDropdown").val() + ", " + $("#brandDropdown").val());

    var labels = [];
    var data = [];
    for (i in chartData) {
        labels.push(chartData[i].Month);
        data.push(chartData[i].Total);
    }
    mainChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [
                {
                    label: "Sales",
                    backgroundColor: ["#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                    data: data
                }
            ]
        }
    });

    $("#categoryDropdown").change(function () {
        updateProductDropdown();
    });
    $("#productDropdown").change(function () {
        updateBrandDropdown();
    });
    $("#brandDropdown").change(function () {
        updateSalesChart();
    });
});


function updateProductDropdown() {
    var selectedCategory = $("#categoryDropdown").val();
    $.ajax({
        url: "/Home/GetProductsByCategory",
        data: { categoryName: selectedCategory },
        method: "GET",
        success: function (data) {
            {
                $("#productDropdown").empty();
                $("#productDropdown").append('<option value="">Select Product</option>');
                $.each(data, function (i, item) {
                    $("#productDropdown").append(`<option ${(i == 0 ? "selected" : "")} value="${item}">${item}</option>`);
                });
                updateBrandDropdown();
            }
        }
    });
}

function updateBrandDropdown() {
    var selectedProduct = $("#productDropdown").val();
    $.ajax({
        url: "/Home/GetBrandsByProduct",
        data: { productName: selectedProduct },
        method: "GET",
        success: function (data) {
            $("#brandDropdown").empty();
            $("#brandDropdown").append('<option value="">Select Brand</option>');
            $.each(data, function (i, item) {
                $("#brandDropdown").append(`<option ${(i == 0 ? "selected" : "")} value="${item}">${item}</option>`);
            });
            updateSalesChart();
        }
    });
}

function updateSalesChart() {
    var selectedCategory = $("#categoryDropdown").val();
    var selectedProduct = $("#productDropdown").val();
    var selectedBrand = $("#brandDropdown").val();


    $.ajax({
        url: "/Home/getSalesResults",
        data: {
            categoryName: selectedCategory,
            productName: selectedProduct,
            brandName: selectedBrand
        },
        method: "GET",
        success: function (chartData) {

            var ctx = $('#barChart')

            var labels = [];
            var data = [];
            $('#spanFilters').text("Sales by Month:" + $("#categoryDropdown").val() + ", " + $("#productDropdown").val() + ", " + $("#brandDropdown").val());
            for (i in chartData) {
                labels.push(chartData[i].month);
                data.push(chartData[i].total);
            }

            mainChart.data.datasets = [
                {
                    label: "Sales",
                    backgroundColor: ["#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                    data: data
                }
            ];

            mainChart.update();
        }
    });
}