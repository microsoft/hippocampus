INSERT INTO [dbo].[Sales] (
    [Product Number],
    [Product Name],
    [Product Group],
    [Prod Sub Type],
    [Install Base Trackable Flag],
    [Product Type],
    [Product Line],
    [Sales Order Number],
    [Invoiced Quantity],
    [Invoiced Amount],
    [Ship To Location Country Name],
    [Prod Segment],
    [Customer Name],
    [Customer Number],
    [Quarter],
    [Year]
)
VALUES
('3491845', 'NEURO PIXEL MONITOR 24"', 'EEG', 'Peripheral', 1, 'Accessories', 'BrainRT', 322323, 3, 1200, 'USA', 'Neuro', 'BRAIN HEALTH INSTITUTE', 12346, '2024 Q 1', 2024),
('3491846', 'SYNAPSE ENHANCER HEADSET', 'EEG', 'Wearable', 1, 'Devices', 'BrainRT', 322324, 2, 2200, 'Canada', 'Neuro', 'TORONTO NEUROLOGY LAB', 12347, '2024 Q 2', 2024),
('3491847', 'CEREBRAL SCANNER X200', 'EEG', 'Diagnostic', 1, 'Machinery', 'BrainRT', 322325, 1, 4500, 'Mexico', 'Neuro', 'MEXICO NEURO CENTER', 12348, '2024 Q 2', 2024),
('3491848', 'BRAIN MAPPING KIT PRO', 'EEG', 'Research', 1, 'Equipment', 'BrainRT', 322326, 5, 3000, 'Brazil', 'Neuro', 'RIO BRAIN RESEARCH', 12349, '2024 Q 3', 2024),
('3491849', 'MEMORY ENHANCEMENT DEVICE', 'EEG', 'Therapeutic', 1, 'Devices', 'BrainRT', 322327, 4, 3300, 'Argentina', 'Neuro', 'BUENOS AIRES NEURO CLINIC', 12350, '2024 Q 3', 2024),
('3491850', 'QUANTUM NEUROCOMPUTER', 'EEG', 'Computing', 1, 'Devices', 'BrainRT', 322328, 2, 7600, 'UK', 'Neuro', 'LONDON BRAIN LAB', 12351, '2024 Q 4', 2024),
('3491851', 'ELECTROENCEPHALOGRAPH MODEL Z', 'EEG', 'Monitoring', 1, 'Machinery', 'BrainRT', 322329, 3, 5400, 'France', 'Neuro', 'PARIS NEUROTECH', 12352, '2025 Q 1', 2025),
('3491852', 'VIRTUAL REALITY THERAPY SYSTEM', 'EEG', 'VR', 1, 'Software', 'BrainRT', 322330, 1, 1100, 'Germany', 'Neuro', 'BERLIN VR CLINIC', 12353, '2025 Q 1', 2025),
('3491853', 'PORTABLE MIND READER', 'EEG', 'Portable', 1, 'Devices', 'BrainRT', 322331, 4, 2900, 'Italy', 'Neuro', 'MILAN MENTAL HEALTH', 12354, '2025 Q 2', 2025),
('3491854', 'DEEP LEARNING NEURAL ANALYZER', 'EEG', 'AI', 1, 'Software', 'BrainRT', 322332, 3, 6100, 'Spain', 'Neuro', 'BARCELONA BRAIN PROJECT', 12355, '2025 Q 2', 2025),
('3491855', 'BRAIN SIGNAL AMPLIFIER', 'EEG', 'Enhancement', 1, 'Devices', 'BrainRT', 322333, 2, 1750, 'Norway', 'Neuro', 'OSLO NEURO LAB', 12356, '2025 Q 3', 2025),
('3491856', 'NEURO FEEDBACK INTERFACE', 'EEG', 'Interface', 1, 'Devices', 'BrainRT', 322334, 5, 4100, 'Sweden', 'Neuro', 'STOCKHOLM BRAIN CENTER', 12357, '2025 Q 3', 2025),
('3491857', 'COGNITIVE LOAD SENSOR', 'EEG', 'Sensor', 1, 'Devices', 'BrainRT', 322335, 1, 890, 'Denmark', 'Neuro', 'COPENHAGEN MIND LAB', 12358, '2025 Q 4', 2025),
('3491858', 'NEUROPLASTICITY STIMULATOR', 'EEG', 'Stimulation', 1, 'Devices', 'BrainRT', 322336, 4, 2400, 'Finland', 'Neuro', 'HELSINKI BRAIN INSTITUTE', 12359, '2025 Q 4', 2025),
('3491859', 'AUTONOMOUS NEURO MONITORING DRONE', 'EEG', 'Surveillance', 1, 'Equipment', 'BrainRT', 322337, 3, 3650, 'Ireland', 'Neuro', 'DUBLIN NEUROTECH', 12360, '2026 Q 1', 2026)
;


INSERT INTO [dbo].[Assets] ( 
     [ACCOUNT_NUMBER]
      ,[ACCOUNT_NAME]
      ,[INSTALL_DATE]
      ,[REGISTERED_DATE]
      ,[SHIP_DATE]
      ,[ASSET_NUMBER]
      ,[SERIAL_NUMBER]
      ,[ADDR_LINE_1]
      ,[ADDR_LINE_1_1]
      ,[CITY]
      ,[COUNTRY]
      ,[STATE]
      ,[ZIPCODE]
      ,[PRODUCT_DESC]
      ,[PART_NUM]
      ,[PROD_SEGMENT]
      ,[PROD_CLASS]
      ,[PROD_GROUP]
      ,[PROD_LINE]
)VALUES
(39449, 'GLOBAL HEALTH CORP', '2024-05-09', '2024-05-01', '2024-04-30', 'A-00001', 'SN-001A', '100 Infinity Loop', 'Suite 42', 'Techville', 'USA', 'CA', '90001', 'ADVANCED MRI SCANNER', 'MRI-9000X', 'Medical Imaging', 'Diagnostics', 'Radiology', 'ImagingTech'),
(39450, 'URBAN WELLNESS CLINIC', '2024-05-08', '2024-04-29', '2024-04-28', 'A-00002', 'SN-002B', '500 Health Blvd', 'Floor 7', 'Medicity', 'Canada', 'ON', 'K1A 0B1', 'PORTABLE ULTRASOUND', 'ULT-8000P', 'Ultrasound', 'Portable', 'Diagnostic', 'UltraScan'),
(39451, 'OCEAN VIEW HOSPITAL', '2024-05-07', '2024-04-28', '2024-04-27', 'A-00003', 'SN-003C', '88 Coastal Road', 'Building B', 'Seaport', 'UK', 'LN', 'LN10 6QL', 'ECHOCARDIOGRAM MACHINE', 'ECHO-7000H', 'Cardiology', 'Heart Monitoring', 'Cardiac', 'HeartBeat'),
(39452, 'MOUNTAIN PEAK MEDICAL', '2024-05-06', '2024-04-27', '2024-04-26', 'A-00004', 'SN-004D', '777 High Altitude Ave', 'Unit 33', 'Highland', 'Switzerland', 'ZH', '8001', 'BLOOD ANALYSIS SYSTEM', 'BAS-5000B', 'Lab Equipment', 'Blood Testing', 'Hematology', 'BloodWorks'),
(39453, 'DESERT SPRINGS SURGERY', '2024-05-05', '2024-04-26', '2024-04-25', 'A-00005', 'SN-005E', '303 Arid Way', 'Office 19', 'Drytown', 'Australia', 'NSW', '2000', 'LAPAROSCOPY TOWER', 'LAP-3000T', 'Surgery', 'Minimally Invasive', 'Endoscopy', 'ScopeTech'),
(39454, 'RAIN FOREST REMEDIES', '2024-05-04', '2024-04-25', '2024-04-24', 'A-00006', 'SN-006F', '202 Jungle Junction', 'Hut 8', 'Greenwood', 'Brazil', 'AM', '69000', 'COMPOUND MICROSCOPE', 'MIC-2000C', 'Microscopy', 'Research', 'Biology', 'MicroView'),
(39455, 'CITY HOSPITAL DBA METROPOLITAN MEDICAL', '2024-05-03', '2024-04-24', '2024-04-23', 'A-00007', 'SN-007G', '909 Urban Ave', 'Penthouse', 'Metroville', 'Japan', 'TK', '100-0001', 'DIGITAL X-RAY SYSTEM', 'DXR-4000D', 'Radiography', 'Imaging', 'X-Ray', 'RayScan'),
(39456, 'NORTHERN LIGHTS HEALTH', '2024-05-02', '2024-04-23', '2024-04-22', 'A-00008', 'SN-008H', '11 Aurora Street', 'Igloo 3', 'Coldtown', 'Norway', 'OS', '0101', 'DEFIBRILLATOR UNIT', 'DEF-3000U', 'Emergency', 'Life Support', 'Cardiac Care', 'ShockAid'),
(39457, 'SUNNY VALLEY MEDICAL', '2024-05-01', '2024-04-22', '2024-04-21', 'A-00009', 'SN-009I', '456 Sunshine Blvd', 'Villa 12', 'Sunnyvale', 'Spain', 'MD', '28001', 'PATIENT MONITORING SYSTEM', 'PMS-6000M', 'Monitoring', 'Vital Signs', 'ICU', 'VitaMon'),
(39458, 'RIVERBEND HEALTHCARE', '2024-04-30', '2024-04-21', '2024-04-20', 'A-00010', 'SN-010J', '321 Riverside Drive', 'Dock 5', 'Rivercity', 'Germany', 'BE', '10115', 'INFUSION PUMP', 'INF-7000P', 'Infusion', 'Drug Delivery', 'IV Therapy', 'PumpPro'),
(39459, 'GOLDEN GATE WELLNESS', '2024-04-29', '2024-04-20', '2024-04-19', 'A-00011', 'SN-011K', '49 Golden Road', 'Suite 24K', 'Bridgeview', 'USA', 'CA', '94129', 'ELECTROSURGICAL UNIT', 'ESU-5000E', 'Surgery', 'Cauterization', 'Operative', 'SurgeTech'),
(39460, 'CRYSTAL LAKE CLINIC', '2024-04-28', '2024-04-19', '2024-04-18', 'A-00012', 'SN-012L', '67 Clearwater Bay', 'Cottage 6', 'Crystalburg', 'Canada', 'BC', 'V9N 0A1', 'ANESTHESIA MACHINE', 'ANM-3000A', 'Anesthesia', 'Sedation', 'OR', 'AnesthoPro'),
(39461, 'PRISTINE PEAKS HEALTH', '2024-04-27', '2024-04-18', '2024-04-17', 'A-00013', 'SN-013M', '14 Snowcap Lane', 'Lodge 7', 'Frostville', 'Sweden', 'ST', '113 47', 'VENTILATOR', 'VEN-8000V', 'Respiratory', 'Breathing Support', 'Pulmonology', 'BreatheEasy'),
(39462, 'OASIS OUTPATIENT SERVICES', '2024-04-26', '2024-04-17', '2024-04-16', 'A-00014', 'SN-014N', '333 Desert Road', 'Oasis 21', 'Dunesville', 'UAE', 'DU', '00000', 'SURGICAL LASER SYSTEM', 'LAS-9000S', 'Surgery', 'Precision Cutting', 'Laser Surgery', 'LaserTech'),
(39463, 'WINDY CITY MEDICAL', '2024-04-25', '2024-04-16', '2024-04-15', 'A-00015', 'SN-015O', '101 Windward Circle', 'Tower 9', 'Galeville', 'USA', 'IL', '60606', 'ORTHOPEDIC DRILL', 'ORD-2000D', 'Orthopedics', 'Bone Surgery', 'Surgical', 'DrillMax')
;