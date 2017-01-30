
$(document).ready(function () {
    
    var options =
        {
            fillOpacity: 0.5,
            mapKey: 'alt',
            fillColor: "000000",
            listKey: 'alt',
            scaleMap: false,
            stroke: true,           
            strokeColor: "3320FF",
            strokeOpacity: 0.5,
            strokeWidth: 4,
            singleSelect: true,
            toolTipClose: ["tooltip-click", "area-click", "area-mouseout"],
            showToolTip: true,
            render_highlight: {
                fade: false
            }
        };

    $('#man').mapster($.extend({}, options,{

        onClick: function (e) {
            if (e.key === 'leg') {
                $('#MaleLegDIV').show();
                $('#DefaultMaleDIV').hide();
            }
            if (e.key === 'pelvis') {
                $('#MalePelvisDIV').show();
                $('#DefaultMaleDIV').hide();
            }
            if (e.key === 'abdomen') {
                $('#MaleAbdomenDIV').show();
                $('#DefaultMaleDIV').hide();
            }
            if (e.key === 'chest') {
                $('#MaleChestDIV').show();
                $('#DefaultMaleDIV').hide();
            }
            if (e.key === 'neck') {
                $('#MaleNeckDIV').show();
                $('#DefaultMaleDIV').hide();
            }
            if (e.key === 'hand') {
                $('#MaleHandDIV').show();
                $('#DefaultMaleDIV').hide();
            }
            if (e.key === 'head') {
                $('#MaleHeadDIV').show();
                $('#DefaultMaleDIV').hide();
            }
            if (e.key === 'backView') {
                $('#MaleBackViewDIV').show();
                $('#DefaultMaleDIV').hide();
            }

        },
        areas: [
        {
            key: "leg",
            toolTip: 'LEG'
        },
        {
            key: "pelvis",
            toolTip: 'PELVIS'

        },
        {
            key: "abdomen",
            toolTip: 'ABDOMEN'

        },
        {
            key: "chest",
            toolTip: 'CHEST'

        },
        {
            key: "hand",
            toolTip: 'HAND'

        },
        {
            key: "neck",
            toolTip: 'NECK'

        },
        {
            key: "head",
            toolTip: 'HEAD'

        }
        ]

    }));


    $('#manLeg').mapster($.extend({}, options,{

        onClick: function (e) {
            if (e.key === 'zoomOut') {
                $('#DefaultMaleDIV').show();
                $('#MaleLegDIV').hide();
            }
            if (e.key === 'backView') {
                $('#MaleLegDIV').hide();
                $('#MaleBackLegDIV').show();
            }
            if (e.key === 'toes')
            {
                
                $.ajax({
                    url: "SympsService.asmx/GetSymptoms",
                    method: "post",
                    dataType: "json",
                    data: JSON.stringify({ organ_name: "toes" }),
                    contentType: "application/json",
                    success: function (data) {
                        createDataTable('#choiseTable', null);
                        createDataTable("#symptomsTable", null);
                        $('#choiseTable').on("click", "tbody button", function (evt) { moveRow(evt, '#choiseTable', '#symptomsTable'); })
                        $('#symptomsTable').on("click", "tbody button", function (evt) { moveRow(evt, '#symptomsTable', '#choiseTable'); })
                        var sympList = 'GetSymptoms' ? JSON.parse(data.d) : data.d;
                        createDataTable('#symptomsTable', sympList);

                        function createDataTable(target, data) {

                            $(target).DataTable({
                                destroy: true,
                                paging: false, searching: false, info: false, data: data,
                                columnDefs: [{
                                    targets: [-1], render: function () {
                                        return "<button type='button'>" + (target == '#choiseTable' ? 'Remove' : 'Choose') + "</button>"
                                    }
                                }],
                                columns: [
                                    {
                                        'data': 'Sympt',
                                        'title': 'toes Symptoms',
                                        class: 'center'
                                    },
                                {
                                    'data': null, 'title': 'Action'

                                }
                                ]

                            });
                        }

                        function moveRow(evt, fromTable, toTable) {

                            var table1 = $(fromTable).DataTable();
                            var table2 = $(toTable).DataTable();
                            var tr = $(evt.target).closest("tr");
                            var row = table1.rows(tr);
                            // since we are only dealing with data for once cell I just grab it and make a new data object

                            var obj = { 'Sympt': row.data()[0].Sympt };
                            table2.row.add(obj).draw();
                            row.remove().draw();

                        }
                    },
                    error: function (error, status) {
                        console.log(error);
                        debugger;
                    }
                });
                
                
            }
            if (e.key === 'ankel') {
                $.ajax({
                    url: "SympsService.asmx/GetSymptoms",
                    data: { organ_name: "ankel" },
                    method: "post",
                    dataType: "json",
                    success: function (data) {
                        var Variable = $('#symptomsTable').DataTable({
                            destroy: true,
                            data: data,
                            columns: [{
                                'data': 'Sympt',
                                'title': 'Ankel Symptoms',
                                class: 'center'
                            }],
                        });
                        Variable.$('td').onClick(function () {
                            var sData = oTable.fnGetData(this);
                            alert('The cell clicked on had the value of ' + sData);
                        });
                    },
                    error: function (error) {
                        console.log(error);
                    }
                })
            }
            if (e.key === 'shin') {
                $.ajax({
                    url: "SympsService.asmx/GetSymptoms",
                    data: { organ_name: "shin" },
                    method: "post",
                    dataType: "json",
                    success: function (data) {
                        var Variable = $('#symptomsTable').DataTable({
                            destroy: true,
                            data: data,
                            columns: [
                                {
                                    'data': 'Sympt',
                                    'title': 'Shin Symptoms',
                                    class: 'center'
                                }
                            ],
                            
                        });
                    },
                    error: function (error) {
                        console.log(error);
                    }
                })
            }
            if (e.key === 'foot') {

                $.ajax({
                    url: "SympsService.asmx/GetSymptoms",
                    data: { organ_name: "foot" },
                    method: "post",
                    dataType: "json",
                    success: function (data) {
                        var Variable = $('#symptomsTable').DataTable({
                            destroy: true,
                            data: data,
                            columns: [{
                                'data': 'Sympt',
                                'title': 'Foot Symptoms',
                                class: 'center'
                            }],
                        });
                    },
                    error: function (error) {
                        console.log(error);
                    }
                })
            }
            if (e.key === 'knee') {
                $.ajax({
                    url: "SympsService.asmx/GetSymptoms",
                    data: { organ_name: "knee" },
                    method: "post",
                    dataType: "json",
                    success: function (data) {
                        var Variable = $('#symptomsTable').DataTable({
                            destroy: true,
                            data: data,
                            columns: [{
                                'data': 'Sympt',
                                'title': 'Knee Symptoms',
                                class: 'center'
                            }],
                        });
                    },
                    error: function (error) {
                        console.log(error);
                    }
                })
                
            }
            if (e.key === 'thigh') {
                $.ajax({
                    url: "SympsService.asmx/GetSymptoms",
                    data: { organ_name: "thigh" },
                    method: "post",
                    dataType: "json",
                    success: function (data) {
                        var Variable = $('#symptomsTable').DataTable({
                            destroy: true,
                            data: data,
                            columns: [{
                                'data': 'Sympt',
                                'title': 'Thigh Symptoms',
                                class: 'center'
                            }],
                        });
                    },
                    error: function (error) {
                        console.log(error);
                    }
                })
            }
            
            },
        
        areas: [
        {
            key: "toes",
            toolTip: 'TOES'
        },
        {
            key: "ankel",
            toolTip: 'ANKEL'
        },
        {
            key: "shin",
            toolTip: 'SHIN'
        },
        {
            key: "foot",
            toolTip: 'FOOT'
        },
        {
            key: "knee",
            toolTip: 'KNEE'
        },
        {
            key: "thigh",
            toolTip: 'THIGH'

        }
        ]

    }));
    $('#manPelvis').mapster($.extend({}, options, {

        onClick: function (e) {
            if (e.key === 'zoomOut') {
                $('#DefaultMaleDIV').show();
                $('#MalePelvisDIV').hide();
            }
            if (e.key === 'backView') {
                $('#MalePelvisDIV').hide();
                $('#MaleButtockDIV').show();
            }
        },
        areas: [
        {
            key: "groin",
            toolTip: 'GROIN'
        },
        {
            key: "pelvis",
            toolTip: 'PELVIS'
        },
        {
            key: "hip",
            toolTip: 'HIP'
        },
        {
            key: "genitals",
            toolTip: 'GENITALS'
        }
        ]

    }));

    $('#manAbdomen').mapster($.extend({}, options, {

           onClick: function (e) {
            if (e.key === 'zoomOut') {
             $('#DefaultMaleDIV').show();
                $('#MaleAbdomenDIV').hide();
            }
            if (e.key === 'backView') {
                $('#MaleAbdomenDIV').hide();
                $('#MaleBackDIV').show();
            }
        },
        areas: [
        {
            key: "lowerAbdomen",
            toolTip: 'LOWER ABDOMEN'
        },
        {
            key: "upperAbdomen",
            toolTip: 'UPPER ABDOMEN'
        }
        ]

    }));

    $('#manChest').mapster($.extend({}, options, {

        onClick: function (e) {
            if (e.key === 'zoomOut') {
                $('#DefaultMaleDIV').show();
                $('#MaleChestDIV').hide();
            }
            if (e.key === 'backView') {
                $('#MaleChestDIV').hide();
                $('#MaleBackDIV').show();
            }
            if (e.key === 'backView')
            {
                
            }
            
        },
        areas: [
        {
            key: "chest",
            toolTip: 'CHEST'
        },
        {
            key: "sturnum",
            toolTip: 'STURNUM'
        },
        {
            key: "lateralChest",
            toolTip: 'LATERAL CHEST'
        },
        {
            key: "genitals",
            toolTip: 'GENITALS'
        }
        ]

    }));

    $('#manHand').mapster($.extend({}, options, {

        onClick: function (e) {
            if (e.key === 'zoomOut') {
                $('#DefaultMaleDIV').show();
                $('#MaleHandDIV').hide();
            }
            if (e.key === 'backView') {
                $('#MaleHandDIV').hide();
                $('#MaleArmDIV').show();
            }
        },
        areas: [
        {
            key: "finger",
            toolTip: 'FINGER'
        },
        {
            key: "palm",
            toolTip: 'PALM'
        },
        {
            key: "wrist",
            toolTip: 'WRIST'
        },
        {
            key: "forearmFlexor",
            toolTip: 'FOREARM (FLEXOR)'
        },
        {
            key: "elbow",
            tooltip: 'ELBOW'

        },
        {
            key: "upperArmBicep",
            tooltip: 'UPPER ARM(BICEP)'

        },
        {
            key: "upperArmTricep",
            tooltip: 'UPPER ARM(TRICEP)'

        },
        {
            key: "shoulder",
            tooltip: 'SHOULDER'

        },
        {
            key: "armpit",
            tooltip: 'ARMPIT'

        },
        ]

        }));

    $('#manNeck').mapster($.extend({}, options, {

        onClick: function (e) {
            if (e.key === 'zoomOut') {
                $('#DefaultMaleDIV').show();
                $('#MaleNeckDIV').hide();
            }
            if (e.key === 'backView') {
                $('#MaleNeckDIV').hide();
                $('#MaleBackNeckDIV').show();
            }
        },
        areas: [
        {
            key: "neckFront",
            toolTip: 'NECK(FRONT)'
        }
        ]

    }));

    $('#manHead').mapster($.extend({}, options, {

        onClick: function (e) {
            if (e.key === 'zoomOut') {
                $('#DefaultMaleDIV').show();
                $('#MaleHeadDIV').hide();
            }
            if (e.key === 'backView') {
                $('#MaleHeadDIV').hide();
                $('#MaleBackHeadDIV').show();
            }
        },
        areas: [
        {
            key: "scalp",
            toolTip: 'SCALP'
        },
        {
            key: "eye",
            toolTip: 'EYE'
        },
        {
            key: "nose",
            toolTip: 'NOSE'
        },
        {
            key: "ear",
            toolTip: 'EAR'
        },
        {
            key: "jaw",
            toolTip: 'JAW'
        },
        {
            key: "face",
            toolTip: 'FACE'
        },
        {
            key: "mouth",
            toolTip: 'MOUTH'
        },
        ]

    }));
    $('#manBackView').mapster($.extend({}, options, {

        onClick: function (e) {
            if (e.key === 'leg') {
                $('#MaleBackLegDIV').show();
                $('#MaleBackViewDIV').hide();
            }
            if (e.key === 'buttock') {
                $('#MaleButtockDIV').show();
                $('#MaleBackViewDIV').hide();
            }
            if (e.key === 'back') {
                $('#MaleBackDIV').show();
                $('#MaleBackViewDIV').hide();
            }
            if (e.key === 'arm') {
                $('#MaleArmDIV').show();
                $('#MaleBackViewDIV').hide();
            }
            if (e.key === 'neck') {
                $('#MaleBackNeckDIV').show();
                $('#MaleBackViewDIV').hide();
            }
            
            if (e.key === 'head') {
                $('#MaleBackHeadDIV').show();
                $('#MaleBackViewDIV').hide();
            }
            if (e.key === 'frontView') {
                $('#DefaultMaleDIV').show();
                $('#MaleBackViewDIV').hide();
            }
        },
        areas: [
        {
            key: "leg",
            toolTip: 'LEG'
        },
        {
            key: "buttock",
            toolTip: 'BUTTOCK'
        },
        {
            key: "back",
            toolTip: 'BACK'
        },
        {
            key: "arm",
            toolTip: 'ARM'
        },
        {
            key: "neck",
            toolTip: 'NECK'
        },
        {
            key: "head",
            toolTip: 'HEAD'
        },
        ]

    }));
    $('#manBackLeg').mapster($.extend({}, options, {

        onClick: function (e) {
            if (e.key === 'zoomOut') {
                $('#MaleBackViewDIV').show();
                $('#MaleBackLegDIV').hide();
            }
            if (e.key === 'frontView') {
                $('#MaleBackLegDIV').hide();
                $('#MaleLegDIV').show();
            }
        },
        areas: [
        {
            key: "toes",
            toolTip: 'TOES'
        },
        {
            key: "sole",
            toolTip: 'SOLE'
        },
        {
            key: "ankel",
            toolTip: 'ANKEL'
        },
        {
            key: "calf",
            toolTip: 'CALF'
        },
        {
            key: "backOfKnee",
            toolTip: 'BACK OF KNEE'
        },
        {
            key: "hamstring",
            toolTip: 'HAMSTRING'
        }
        ]

    }));
    $('#manButtock').mapster($.extend({}, options, {

        onClick: function (e) {
            if (e.key === 'zoomOut') {
                $('#MaleBackViewDIV').show();
                $('#MaleButtockDIV').hide();
            }
            if (e.key === 'frontView') {
                $('#MaleButtockDIV').hide();
                $('#MalePelvisDIV').show();
            }
        },
        areas: [
        
        {
            key: "hip",
            toolTip: 'HIP'
        },
        {
            key: "buttock",
            toolTip: 'BUTTOCK'
        },
        ]

    }));
    $('#manBack').mapster($.extend({}, options, {

        onClick: function (e) {
            if (e.key === 'zoomOut') {
                $('#MaleBackViewDIV').show();
                $('#MaleBackDIV').hide();
            }
            if (e.key === 'frontView') {
                $('#MaleBackDIV').hide();
                $('#MaleAbdomenDIV').show();
            }
        },
        areas: [
        {
            key: "lowerSpine",
            toolTip: 'LOWER SPINE'
        },
        {
            key: "back",
            toolTip: 'BACK'
        },
        {
            key: "upperSpine",
            toolTip: 'UPPER SPINE'
        }
        ]

    }));
    $('#manBackArm').mapster($.extend({}, options, {

        onClick: function (e) {
            if (e.key === 'zoomOut') {
                $('#MaleBackViewDIV').show();
                $('#MaleArmDIV').hide();
            }
            if (e.key === 'frontView') {
                $('#MaleArmDIV').hide();
                $('#MaleHandDIV').show();
            }
        },
        areas: [
        {
            key: "finger",
            toolTip: 'FINGER'
        },
        {
            key: "wrist",
            toolTip: 'WRIST'
        },
        {
            key: "hand",
            toolTip: 'HAND'
        },
        {
            key: "forearm",
            toolTip: 'FOREARM'
        },
        {
            key: "elbow",
            toolTip: 'ELBOW'
        },
        {
            key: "upperArm",
            toolTip: 'UPPER ARM'
        },
        {
            key: "shoulder",
            toolTip: 'SHOULDER'
        },
        ]

    }));
    $('#manBackNeck').mapster($.extend({}, options, {

        onClick: function (e) {
            if (e.key === 'zoomOut') {
                $('#MaleBackViewDIV').show();
                $('#MaleBackNeckDIV').hide();
            }
            if (e.key === 'frontView') {
                $('#MaleBackNeckDIV').hide();
                $('#MaleNeckDIV').show();
            }
        },
        areas: [
        {
            key: "neck",
            toolTip: 'NECK(BACK)'
        }
        ]

    }));
    $('#manBackHead').mapster($.extend({}, options, {

        onClick: function (e) {
            if (e.key === 'zoomOut') {
                $('#MaleBackViewDIV').show();
                $('#MaleBackHeadDIV').hide();
            }
            if (e.key === 'frontView') {
                $('#MaleBackHeadDIV').hide();
                $('#MaleHeadDIV').show();
            }
        },
        areas: [
        {
            key: "scalp",
            toolTip: 'SCALP'
        }
        ]

    }));
   
   
           });
