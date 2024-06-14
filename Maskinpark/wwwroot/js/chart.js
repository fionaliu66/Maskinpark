
        function createPieChart(chartId, runningMachines, shutdownMachines) {
        var ctx = document.getElementById(chartId).getContext('2d');
        var machineStatusChart = new Chart(ctx, {
            type: 'pie',
            data: {
                labels: ['Running', 'Shutdown'],
                datasets: [{
                    data: [runningMachines, shutdownMachines],
                    backgroundColor: ['#36A2EB', '#FF6384']
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false
            }
        });
    }


